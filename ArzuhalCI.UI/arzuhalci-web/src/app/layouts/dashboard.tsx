import { SidebarProvider, SidebarTrigger } from "@/src/shared/ui";
import { ReactNode } from "react";
import { AppSidebar } from "@/src/shared/components";

export const dashboardMetadata = {
    title: "ArzuhalCI Dashboard",    
}

export function DashboardLayout({ children  } : { children: ReactNode} ) {
    

    return (
        <SidebarProvider>
            <AppSidebar />
            <main >
                <SidebarTrigger />
                <section className="p-4">
                    { children}
                </section>
            </main>
        </SidebarProvider>
    )
}