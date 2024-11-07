'use client';

import { ReactNode } from "react";
import { useFormStatus } from "react-dom";
import { Button } from "../ui";


export function SubmitButton({ children} : { children: ReactNode}) {
    const { pending } = useFormStatus();

    return (
        <Button type="submit" disabled={pending}>
            { children}
        </Button>
    )
}