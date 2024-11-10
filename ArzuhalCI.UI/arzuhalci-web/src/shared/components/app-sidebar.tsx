import { HomeIcon, List, PlusIcon, ScaleIcon } from "lucide-react";
import { Sidebar, SidebarContent, SidebarFooter, SidebarGroup, SidebarGroupContent, SidebarGroupLabel, SidebarHeader, SidebarMenu, SidebarMenuButton, SidebarMenuItem } from "../ui";
import Link from "next/link";

// Menu items.
const items = [
    {
      title: "Home",
      url: "/",
      icon: HomeIcon,
    },
    {
      title: "Entries",
      url: "/entry",
      icon: List,
    },    
    { 
        title: "New Entry",
        url: "/entry/new",
        icon: PlusIcon
    }
  ]


export function AppSidebar() {
    return (
        <Sidebar>            
            <SidebarHeader>
                <div className="flex gap-4">
                    <ScaleIcon />
                    <span>ArzuhalCI</span>
                </div>
            </SidebarHeader>
            <SidebarContent>
                <SidebarGroup>                    
                    <SidebarGroupContent>
                        <SidebarMenu>
                            {
                                items.map((item) => (
                                    <SidebarMenuItem key={item.title}>
                                        <SidebarMenuButton asChild>
                                            <Link href={item.url}>
                                                <item.icon />
                                                <span>{item.title}</span>
                                            </Link>
                                        </SidebarMenuButton>
                                    </SidebarMenuItem>
                                ))
                            }
                        </SidebarMenu>
                    </SidebarGroupContent>
                </SidebarGroup>
                <SidebarGroup />
            </SidebarContent>
            <SidebarFooter>                
            </SidebarFooter>
        </Sidebar>
    )
    
}