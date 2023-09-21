package main

import (
	"encoding/json"
	"fmt"
	"os"
	"path/filepath"
	"strings"

	protoparser "github.com/yoheimuta/go-protoparser/v4"
)

const (
	PROTO_DIR  = "../GenProtos/"
	OUTPUT_DIR = "../Proto2json_Output/"
)

func main() {

	{
		_, err := os.Stat(OUTPUT_DIR)
		if err == nil {
			os.Remove(OUTPUT_DIR)
		}
		if os.IsNotExist(err) {
		}
	}

	os.Mkdir(OUTPUT_DIR, 0777)

	{
		var files []string

		err := filepath.Walk(PROTO_DIR, func(path string, info os.FileInfo, err error) error {
			if info.IsDir() {
				return nil
			}
			files = append(files, path)
			return nil
		})
		if err != nil {
			panic(err)
		}
		for _, file := range files {
			reader, err := os.Open(file)
			if err != nil {
				fmt.Fprintf(os.Stderr, "failed to open %s, err %v\n", file, err)
				return
			}
			defer reader.Close()

			got, err := protoparser.Parse(reader)
			if err != nil {
				fmt.Fprintf(os.Stderr, "failed to parse %s, err %v\n", file, err)
				return
			}

			gotJSON, err := json.MarshalIndent(got, "", "  ")
			if err != nil {
				fmt.Fprintf(os.Stderr, "failed to marshal, err %v\n", err)
			}
			var filenameWithSuffix = filepath.Base(file)
			os.WriteFile(OUTPUT_DIR+strings.TrimSuffix(filenameWithSuffix, filepath.Ext(filenameWithSuffix))+".json", gotJSON, 0644)
		}
	}
}
