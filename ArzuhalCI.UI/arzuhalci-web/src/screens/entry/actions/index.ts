'use server';

export async function AddNewEntry(formData: FormData) {
    const rawFormData = {
        propt: formData.get('prompt')
    }
    console.log('Action: ', rawFormData);
}