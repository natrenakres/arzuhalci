-- sample for running model.
select ai.ollama_generate
( 'llama3'
, 'what is the typical weather like in Alabama in June'
, host=>'http://host.docker.internal:11434' -- tells pgai that Ollama is running on the host when pgai is in a docker container
)

-- fallow readme.md in project files
select set_config('ai.ollama_host', 'http://host.docker.internal:11434', false);



SELECT ai.create_vectorizer( 
   'analyses'::regclass,
    destination => 'analyses_petitions_embeddings',
    embedding => ai.embedding_openai('text-embedding-3-small', 768),
    chunking => ai.chunking_recursive_character_text_splitter('petition')
);

SELECT * 
FROM ai.ollama_list_models()
ORDER BY size DESC
;


SELECT 
   chunk,
   embedding <=> ai.ollama_embed('llama3', 'some-query') as distance
FROM analyses_petitions_embeddings_store
ORDER BY distance
LIMIT 5;