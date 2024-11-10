'use server';
import { Entry } from "@/src/entities/entry";
import { getPrompt, parseOutput } from "@/src/shared/lib";
import { getAccessToken } from "@auth0/nextjs-auth0";


export async function addAnalysis(prevState: any, formData: FormData) { 
    const petition = formData.get('petition');
    const { accessToken } = await getAccessToken();

    const response = await fetch(`${process.env.AUTH0_AUDIENCE}/api/analysis`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',                
            'Authorization': `Bearer ${accessToken}`
        },
        body: JSON.stringify({
            petition
        })
    })

    if (response.status !== 204) {
        return { message: 'Cannot add analysis', analysis: prevState}
    }

    return { message: 'Analysis added successfully', analysis: prevState}
}

export async function addNewEntry(prevState: any, formData: FormData) {
    const content = formData.get('content');
    const prompt = await getPrompt(content?.toString());

    const {accessToken} = await getAccessToken();    

    const response = await fetch(`${process.env.AUTH0_AUDIENCE}/api/entries`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',                
            'Authorization': `Bearer ${accessToken}`
        },
        body: JSON.stringify({
            prompt
        })
    })

    if (response.status !== 201) {
        return { analyse: undefined, message: 'Entry cannot be created', entryId: undefined, status: undefined}
    }
    

    const entry: Entry = await response.json();

    const analyse = await parseOutput(entry.output);    

    return { analyse, message: 'Your entry successfully created', entryId: entry.id, status: entry.status };
}



