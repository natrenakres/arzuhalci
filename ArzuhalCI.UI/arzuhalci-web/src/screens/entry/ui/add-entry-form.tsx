'use client';

import { Label, Textarea } from "@/src/shared/ui";
import { SubmitButton } from "@/src/shared/components";
import { addNewEntry } from "../actions";
import { useFormState } from "react-dom";
import { EntryStatus } from "@/src/entities/entry";
import { AddAnalyseForm } from "./add-analyse-form";


const initialState = {
    analyse: undefined,
    entryId: undefined,
    status: undefined,
    message: ''
  };


export function AddEntryForm() {    
    const [state, formAction] = useFormState(addNewEntry, initialState);

    return (
        <>
            <form action={formAction}>
                <div className="mb-4">
                    <Label htmlFor="prompt">Your Prompt for petition:</Label>
                    <Textarea name="prompt" required/>
                </div> 
                <p>{state?.message}</p>               
                <SubmitButton>Submit</SubmitButton>
            </form>
            {
                state?.status === EntryStatus.Analysed && <AddAnalyseForm analysis={state?.analyse} />
            }
        </>
    )
}