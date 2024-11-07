import { Input, Label, Textarea } from "@/src/shared/ui";
import { SubmitButton } from "@/src/shared/components";
import { AddNewEntry } from "../actions";
export function NewEntryScreen() {

    return (
        <div className="p-4 flex flex-col gap-4">
            <form action={AddNewEntry}>
                <div className="mb-4">
                    <Label htmlFor="prompt">Your Prompt for petition:</Label>
                    <Textarea name="prompt" required/>
                </div>                
                <SubmitButton>Submit</SubmitButton>
            </form>
        </div>
    )
    
}