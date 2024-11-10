

# pgai

## Installation
1. Run the TimescaleDB Docker image
2. Enable the pgai extension in your database 
CREATE EXTENSION IF NOT EXISTS ai CASCADE;

## Usage of pgai
Automatically create and sync LLM embeddings for your data
Automate AI embedding with [pgai Vectorizer](https://github.com/timescale/pgai/blob/main/docs/vectorizer.md)

### Configure pgai for Ollama
select set_config('ai.ollama_host', 'http://host.docker.internal:11434', false);

List the models supported by your AI provider in pgai:
`
SELECT * 
FROM ai.ollama_list_models()
ORDER BY size DESC
;`

Create embeding table

`
SELECT ai.create_vectorizer(
'analyses'::regclass,
destination => 'analyses_petitions_embeddings',
embedding => ai.embedding_openai('text-embedding-3-small', 768),
chunking => ai.chunking_recursive_character_text_splitter('petition')
);
`
Search your data using vector and [semantic search](https://github.com/timescale/pgai?tab=readme-ov-file#search-your-data-using-vector-and-semantic-search)

`
SELECT
chunk,
embedding <=> ai.ollama_embed('llama3', 'some-query') as distance
FROM analyses_petitions_embeddings_store
ORDER BY distance
LIMIT 5;
`

