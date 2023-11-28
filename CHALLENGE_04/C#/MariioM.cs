using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string data = "3n3E65A-nE65A\r\nU6Z1WWc0LP-U6Z1c0LP\r\nla6bqS-la6bqS\r\nlKyxSLIEj-lKyxSLIEj\r\n7HIKAPFYsK-7HIAPFYs\r\nIfhDJjaZKJ-IfhDjaZK\r\n1ynAjanFox-1yAjaFox\r\nvi2Yqle-vi2Yqle\r\nSXxyqnzER-SXxyqnzER\r\nuWWKcD3b-uKcD3b\r\nfxwzTMRB-fxwzTMRB\r\n1f1dLc4p-fdLc4p\r\nH0nY8w-H0nY8w\r\n1tVQjP4-1tVQjP4\r\no8sRM-o8sRM\r\nHn2XWpspJq-Hn2XWsJq\r\n88pauAKQ-pauAKQ\r\nSF5yFf3uW-S5yf3uW\r\nKOjaML-KOjaML\r\nn1sjIG-n1sjIG\r\nH3u4IEwR-H3u4IEwR\r\nEr1iMVvtSb-Er1iMVvtSb\r\n6bDBFweu3-6bDBFweu3\r\nQMG2y-QMG2y\r\nQqS8zu-QqS8zu\r\nnWf2oHc2D-nWfoHcD\r\nywhoHTg-ywhoHTg\r\n5rS6rC-5S6C\r\nkZkSVr-ZSVr\r\nKkGQLG-KkQL\r\nJ8X6VNHKk-J8X6VNHKk\r\nhs5CsfYsN2-h5CfYN2\r\nO2hrQ-O2hrQ\r\nUU7HuFY-7HuFY\r\nvSlgP-vSlgP\r\nLO43CA6h-LO43CA6h\r\nrADjgAXZbD-rjgXZb\r\n219JS-219JS\r\nTw6jlpH-Tw6jlpH\r\nZmfY62-ZmfY62\r\nXh4lMhN-X4lMN\r\n9wPi1-9wPi1\r\nLC3ucqzRev-LC3ucqzRev\r\neqRKXqZzCH-eRKXZzCH\r\nm9Rsx1-m9Rsx1\r\nWKrbn0jLE-WKrbn0jLE\r\nMsW8Mg-sW8g\r\nOKdIPOl-KdIPl\r\nN2ZA7H-N2ZA7H\r\nF86afig-F86afig\r\nBvEzt4ys-BvEzt4ys\r\nwyAmFlx7m-wyAFlx7\r\n73sBHIzZTU-73sBHIzZTU\r\nE5liPXG3ZM-E5liPXG3ZM\r\nwohjWqIEG-wohjWqIEG\r\nAjw0o0-Ajwo\r\nV3ridipc-V3rdpc\r\nysikPhv-ysikPhv\r\niQSz654tNX-iQSz654tNX\r\nqYSwYKifb-qSwKifb\r\nW79773fSH-W93fSH\r\nqNWDAUt-qNWDAUt\r\ni8cDcz-i8Dz\r\nDhJS4-DhJS4\r\nj2TiHE-j2TiHE\r\nm4fpbb2zI-m4fp2zI\r\nbNirf51-bNirf51\r\naPNkUTXWs-aPNkUTXWs\r\nEfsBW8-EfsBW8\r\nsafHshz-afHhz\r\nRycVH06w7-RycVH06w7\r\nIU4n2-IU4n2\r\nlrXEc2N2u-lrXEcNu\r\nbMcOtLT7-bMcOtLT7\r\nhILDoXNIP-hLDoXNP\r\nRoG5ra-RoG5ra\r\nVAbQO-VAbQO\r\nlgnMYBnI-lgMYBI\r\nY5TZwZfJ-Y5TwfJ\r\nwTI9xRn-wTI9xRn\r\nLEs3Fcj7M6-LEs3Fcj7M6\r\niccMmtrl-iMmtrl\r\ng9R8e-g9R8e\r\nXWJWnygqc-XJnygqc\r\nQMLJAm1Kf-QMLJAm1Kf\r\nEfA1kaddYq-EfA1kaYq\r\nieY5aGGV-ieY5aV\r\n3lZn2-3lZn2\r\nVTQVbY-TQbY\r\nKxUMQYJENi-KxUMQYJENi\r\nmPqYGQ-mPqYGQ\r\nIyeJXmUd3c-IyeJXmUd3c\r\nxXsymu5Av-xXsymu5Av\r\niJXvYyTcD-iJXvYyTcD\r\n7VrbUTTKyi-7VrbUKyi\r\nfXr9O6-fXr9O6\r\n4VNq3-4VNq3\r\nsDAec-sDAec\r\nzOAGtZEc-zOAGtZEc\r\nCb2n1GNN-Cb2n1G";
            string[] dataList = data.Split('\n');
            string currentData;
            string[] splitedData;
            char[] password;
            char[] checksum;
            List<char> tokens = new List<char>();
            int count, tokenPosition = 0;
            string[] correctPasswords = new string[data.Length];
            int correctPosition = 0;

            for (int index = 0; index < dataList.Length; index++)
            {
                tokens.Clear();
                currentData = dataList[index];
                splitedData = currentData.Split('-');
                password = splitedData[0].ToCharArray();
                checksum = splitedData[1].ToCharArray();
                foreach (char character in password)
                {
                    count = 0;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (character == password[i])
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        break;
                    }
                    else if (count == 1)
                    {
                        tokens.Add(character);
                        tokenPosition++;
                    }
                }
                count = 0;
                foreach (char tok in tokens)
                {
                    foreach (char chekChar in checksum)
                    {
                        if (chekChar == tok)
                        {
                            count++;
                        }
                    }
                }
                if (count == tokens.Count)
                {
                    correctPasswords[correctPosition] = currentData;
                    correctPosition++;
                    Console.WriteLine(correctPosition + ". " + currentData);
                }
            }
            Console.WriteLine(correctPasswords[32]);
            Console.ReadKey();
        }
    }
}