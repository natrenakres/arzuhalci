import { currentUser, User } from "@clerk/nextjs/server";
import { redirect } from "next/navigation";

async function addCustomerAction(user: User | null) {

    if (!user) {
        throw new Error("user cannot be empty");        
    }

    const response = await fetch(`http://localhost:3001/api/customers`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: `${user.firstName} ${user.lastName}`,
            email: user.emailAddresses,
            identityId: user.id
        })
    });


    if (response.status === 409) {
        console.log('User has already registered');
        return true;
    }

    if (response.status === 201) {
        console.log("New user added successfully");
        return true;
    }


    return false;    
}


export async function NewUserScreen() {
    const user = await currentUser();
    const result = await addCustomerAction(user);

    if (result) {
        redirect('/entry')   
    }

    return (
        <div>Loading...</div>
    )
}