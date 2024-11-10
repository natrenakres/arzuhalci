CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    CREATE TABLE public.customers (
        id uuid NOT NULL,
        identity_id text NOT NULL,
        email text NOT NULL,
        name text NOT NULL,
        CONSTRAINT pk_customers PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    CREATE TABLE public.entries (
        id uuid NOT NULL,
        customer_id uuid NOT NULL,
        status integer NOT NULL,
        analyse_id uuid,
        output text,
        prompt text NOT NULL,
        CONSTRAINT pk_entries PRIMARY KEY (id),
        CONSTRAINT fk_entries_customers_customer_id FOREIGN KEY (customer_id) REFERENCES public.customers (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    CREATE TABLE public.analyses (
        id uuid NOT NULL,
        entry_id uuid NOT NULL,
        mood text NOT NULL,
        negative boolean NOT NULL,
        sentiment_score integer NOT NULL,
        subject text NOT NULL,
        summary text NOT NULL,
        petition text,
        CONSTRAINT pk_analyses PRIMARY KEY (id),
        CONSTRAINT fk_analyses_entries_entry_id FOREIGN KEY (entry_id) REFERENCES public.entries (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    CREATE UNIQUE INDEX ix_analyses_entry_id ON public.analyses (entry_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    CREATE INDEX ix_entries_customer_id ON public.entries (customer_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20241110203957_Init') THEN
    INSERT INTO public."__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20241110203957_Init', '8.0.8');
    END IF;
END $EF$;
COMMIT;

