import '../styles';
import { inter  } from "@/src/app/fonts";
import { ReactNode } from "react";
import { AuthProvider } from "../providers";

export const metadata = {
    title: 'ArzuhalCI App',
    description: 'To ask AI for best Petition result',
  }

  export function RootLayout({ children }: { children: ReactNode }) {
    return (
      <AuthProvider>
        <html lang="en">
          <body className={inter.className}>
              {children}
          </body>
        </html>
      </AuthProvider>
    )
  }
  