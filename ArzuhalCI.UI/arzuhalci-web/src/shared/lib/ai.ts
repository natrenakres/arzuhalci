import z from "zod";
import { StructuredOutputParser } from "langchain/output_parsers";
import { PromptTemplate } from "@langchain/core/prompts";
import { Analyse } from "@/src/entities/analyse";

const parser = StructuredOutputParser.fromZodSchema(
    z.object({
        petition: z
        .string()
        .describe('the petition from entry which user wants to give it to lawyer'),  
      mood: z
        .string()
        .describe('the mood of the person who wrote the journal entry.'),
      subject: z
        .string()
        .describe('the subject of the journal entry.'),
      negative: z
        .boolean()
        .describe(
          'is the journal entry negative? (i.e. does it contain negative emotions?).'
        ),
      summary: z
        .string()
        .describe('quick summary of the entire entry.'),
      color: z
        .string()
        .describe(
          'a hexidecimal color code that represents the mood of the entry. Example #0101fe for blue representing happiness.'
        ),
      sentimentScore: z
        .number()
        .describe(
          'sentiment of the text and rated on a scale from -10 to 10, where -10 is extremely negative, 0 is neutral, and 10 is extremely positive.'
        ),
    })
  );

  export async function getPrompt(content?
    : string) {
    const format_instructions = parser.getFormatInstructions();

    const prompt = new PromptTemplate({
        template:'Analyze the following journal entry. Follow the intrusctions and format your response to match the format instructions, no matter what! \n{format_instructions}\n{entry}',
        inputVariables: ['entry'],
        partialVariables: {
            format_instructions
        }
    })

    const input = await prompt.format({
        entry: content
    });

    return input;
  }

  export async function parseOutput(output:string): Promise<Analyse> {
    try {
        return await parser.parse(output);        
    } catch (error) {
        throw new Error("Parse error during the output parse operation");           
    }
  }