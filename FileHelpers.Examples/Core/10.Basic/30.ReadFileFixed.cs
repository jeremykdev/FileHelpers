﻿using System;
using System.Collections;
using System.Collections.Generic;
using FileHelpers;

namespace ExamplesFramework
{
    //-> {Example.Name:Read Fixed File}
    //-> {Example.Description:Example of how to read a Fixed Length layout file (eg Cobol output)}

    /// <summary>
    /// Example of reading a simple file delimited by | using the Generic Engine
    /// </summary>
    public class ReadFixedFile
        : ExampleBase
    {

        //-> {Example.File:Example.cs}

        /// <summary>
        /// Execute the engine and get some results
        /// </summary>
        public override void Run()
        {
            var engine = new FixedFileEngine<Customer>();
            Customer[] result = engine.ReadFile("input.txt");

            foreach (var detail in result)
            {
                this.Console.WriteLine(" Client: {0},  Name: {1}", detail.CustId, detail.Name);
            }

        }
        //-> {/Example.File}

        //-> {Example.File:RecordClass.cs}
        /// <summary>
        /// Our class we are reading using FileHelpers,  the record breakdown
        /// </summary>
        [FixedLengthRecord()]
        public class Customer
        {
            [FieldFixedLength(5)]
            public int CustId;

            [FieldFixedLength(30)]
            [FieldTrim(TrimMode.Both)]
            public string Name;

            [FieldFixedLength(8)]
            [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
            public DateTime AddedDate;

        }
        //-> {/Example.File}

        //-> {Example.File:Input.txt}
        /*01010 Alfreds Futterkiste          13122005
        12399 Ana Trujillo Emparedados y   23012000
        00011 Antonio Moreno Taquería      21042001
        51677 Around the Horn              13051998
        99999 Berglunds snabbköp           02111999*/
        //-> {/Example.File}

        //-> {Example.File:example_fixedengine.html}
        /* <h2>Fixed File Engine</h2>
         * <p>Lets start with a simple data:</p>
         * ${Input.txt}
         * <p>An simple example layout:</p>
         * ${RecordClass.cs}
         * <p>Let see the result:</p>
         * ${Console}
         */
        //-> {/Example.File}
    }

}
