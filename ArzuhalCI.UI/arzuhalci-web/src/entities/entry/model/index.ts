

export type Entry = {
    status: EntryStatus,
    output: string,
    id: string
}

export enum EntryStatus
{
    Draft,
    Analysed,
    Approved
}