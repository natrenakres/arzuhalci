import { Button } from "@/src/shared/ui";
import Link from "next/link";

export async function HomeScreen() {
  const href = 'entry';

  return (
    <main className="w-screen h-screen dark:bg-black flex justify-center items-center dark:text-white">
      <section className="w-full max-w-[600px] mx-auto">
        <h1 className="text-6xl mb-4">The premier advisor for your legal needs in town.</h1>
        <p className="text-2xl dark:text-white/60 mb-4">Expert guidance for all your legal needs, right here in town. Trust us to provide clear, effective solutions tailored to you.</p>
        <div>
          <Link href={`/${href}`}>
            <Button className="text-xl">get started</Button>
          </Link>           
        </div>
      </section>
    </main>
  )
}