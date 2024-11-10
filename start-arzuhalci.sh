#!/bin/bash

# Docker Compose Up
docker compose up -d

# Run Ollama model which is llama3.2 
docker exec -it ollama ollama run llama3.2
