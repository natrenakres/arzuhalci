import { columns, Payment } from "./columns";
import { DataTable } from "@/src/shared/components";

const data: Array<Payment> = [
    {
      id: "728ed52f",
      amount: 100,
      status: "pending",
      email: "m@example.com",
    }]

export function EntryScreen() {
    return (
        <DataTable columns={columns} data={data} />
    )    
}