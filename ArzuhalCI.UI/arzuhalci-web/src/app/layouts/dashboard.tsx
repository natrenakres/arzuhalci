import { Breadcrumb, BreadcrumbItem, BreadcrumbLink, BreadcrumbList, BreadcrumbPage, BreadcrumbSeparator, Separator, SidebarInset, SidebarProvider, SidebarTrigger } from '@/src/shared/ui';
import { ReactNode } from 'react';
import { AppSidebar } from '@/src/shared/components';
import { UserButton } from '@/src/shared/components/user-button';

export const dashboardMetadata = {
  title: 'ArzuhalCI Dashboard',
};

export function DashboardLayout({ children }: { children: ReactNode }) {
  return (
    <SidebarProvider>
      <AppSidebar />
      <SidebarInset>
        <header className='flex h-16 shrink-0 items-center gap-2 border-b px-4'>        
          <SidebarTrigger className='-ml-1' />
          <Separator orientation='vertical' className='mr-2 h-4' />
          <Breadcrumb>
            <BreadcrumbList>
              <BreadcrumbItem className='hidden md:block'>
                <BreadcrumbLink href='#'>
                  Building Your Application
                </BreadcrumbLink>
              </BreadcrumbItem>
              <BreadcrumbSeparator className='hidden md:block' />
              <BreadcrumbItem>
                <BreadcrumbPage>Data Fetching</BreadcrumbPage>
              </BreadcrumbItem>
            </BreadcrumbList>
          </Breadcrumb>

          <div className='ml-auto flex items-center space-x-4'>
            <UserButton />
          </div>
        </header>
        <section className='p-4'>{children}</section>
      </SidebarInset>
    </SidebarProvider>
  );
}
