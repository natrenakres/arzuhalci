"use client";

import { Analyse } from '@/src/entities/analyse';
import { SubmitButton } from '@/src/shared/components';
import { Textarea } from '@/src/shared/ui';
import { Label } from '@radix-ui/react-label';
import { useFormState } from 'react-dom';
import { addAnalysis } from '../actions';

let initialState = {
    message: '',
    analysis: undefined
}

export async function AddAnalyseForm({ analysis }: { analysis: Analyse }) {    

    const [state, formAction] = useFormState(addAnalysis, initialState);
    
  return (
    <div className="w-full h-full grid grid-cols-3 gap-0 relative">      
      <div className="col-span-2">
        <form action={formAction}>
            <div className='mb-2'>
                <Label htmlFor='petition'>Petition</Label>
                <Textarea id='petition' name='petition' value={analysis.petition}></Textarea>
            </div>        
            <p>
                { state?.message}
            </p>
            <SubmitButton>Submit</SubmitButton>
        </form>
      </div>
      <div className="border-l border-black/5">
        <div
          style={{ background: analysis.color }}
          className="h-[100px] bg-blue-600 text-white p-8"
        >
          <h2 className="text-2xl bg-white/25 text-black">Analysis</h2>
        </div>
        <div>
          <ul role="list" className="divide-y divide-gray-200">
            <li className="py-4 px-8 flex items-center justify-between">
              <div className="text-xl font-semibold w-1/3">Subject</div>
              <div className="text-xl">{analysis.subject}</div>
            </li>

            <li className="py-4 px-8 flex items-center justify-between">
              <div className="text-xl font-semibold">Mood</div>
              <div className="text-xl">{analysis.mood}</div>
            </li>

            <li className="py-4 px-8 flex items-center justify-between">
              <div className="text-xl font-semibold">Negative</div>
              <div className="text-xl">
                {analysis.negative ? 'True' : 'False'}
              </div>
            </li>            
          </ul>
        </div>
      </div>
    </div>    
  );
}
