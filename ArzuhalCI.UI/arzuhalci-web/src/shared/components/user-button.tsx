import { CircleUserRound, ContainerIcon, LogOut } from 'lucide-react';
import Link from "next/link";
import {
  Button,
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '../ui';
import { getSession } from '@auth0/nextjs-auth0';
import { Avatar, AvatarImage, AvatarFallback } from '@radix-ui/react-avatar';

export async function UserButton() {
  const session = await getSession();
  const user = session?.user;

  function getFallback(nickname: string) {
    return `${nickname.charAt(0)}${nickname.charAt(1)}`;
  }

  return (
    <>
      {user && (
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button
              variant='ghost'
              className='relative h-8 w-8 rounded-full ml-2 text-center'
            >
              <Avatar className='h-8 w-8'>
                <AvatarImage
                  src={user.picture ?? ''}
                  alt={user.nickname ?? ''}
                />
                <AvatarFallback className='uppercase'>
                  { getFallback(user.nickname)}
                </AvatarFallback>
              </Avatar>
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent className='w-44' align='end' forceMount>
            <DropdownMenuLabel className='font-normal'>
              <div className='flex flex-col space-y-1'>
                <p className='text-sm font-medium leading-none capitalize'>
                  {user?.nickname}
                </p>
                <p className='text-xs leading-none text-muted-foreground'>
                  {user?.name}
                </p>
              </div>
            </DropdownMenuLabel>
            <DropdownMenuSeparator />
            <DropdownMenuGroup>              
              <Link href='/entry'>
                <DropdownMenuItem>
                  <ContainerIcon className='mr-3' />
                  Entries
                </DropdownMenuItem>
              </Link>
              <Link href='/entry/new'>
                <DropdownMenuItem>
                  <ContainerIcon className='mr-3' />
                  New Entry
                </DropdownMenuItem>
              </Link>
            </DropdownMenuGroup>
            <Link href='/api/auth/logout'>
              <DropdownMenuItem>
                <LogOut className='mr-3' /> Logout
              </DropdownMenuItem>
            </Link>
          </DropdownMenuContent>
        </DropdownMenu>
      )}
    </>
  );
}
