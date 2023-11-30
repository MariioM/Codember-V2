using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string database = "PYmt8hd,jdcrLI,jdcrli@gmail.com,27,London\naN21Mhj,yoHrWHE,oHrWHE@example,40,\n,oHrWHE,oHrWHE@a.com,a,\n2RVxZLzIcs,jvNCJj,jvncjj@hotmail.com,45,Berlin\nXUOUmi9,utuPMN,htuPMN@invalid,,Berlin\nUXMmi9,htuPMN,@@@.com,,Berlin\nY2FCxmg*E4L,4vZtIH,dvztih@gmail.com,27,London\nY2FgXXE4L,DvZtIH,dvztih@gmail.com,27,London\nwYR2DOE,vsWtBk,vsWtBk@example,,Paris\n(MIDUni,3vsWtBk,midu@gmail.com,,Barcelona\nG1WV7gK,RFHWCi,rfhwci@yahoo.com,53,Sydney\nOQc_YTY,bGyjPo,,,BuenosAires\nOQc_YTY,eGyjPo,bGyjPo@example,,Caracas\nuzHXNR,IFLUDB,ifludb@hotmail.com,46,Madrid\nu56gsjt,eBbEBV,eBbEBV@invalid,49,\nQH87Wd,fImzHM,fimzhm@gmail.com,38,Madrid\nDhy92jh,pB1P64,pB1P64@hotmail.com,52,CDMX\n6DkGW62P,ldmcDE,ldmcde@gmail.com,33,Madrid\nB89dht_,nceCp2,nceCp2@invalid,68,Rome\nO8TsZ7,jauTbB,jautbb@gmail.com,45,New York\ntIR9N,yOkZBg,yokzbg@yahoo.com,68,Tokyo\n1KN4ZOe,emuBwK,emubwk@gmail.com,27,London\n2efL9,zAPgvK,zapgvk@outlook.com,33,Paris\nf9Fw1q6tWq,djrWrL,djrwrl@outlook.com,20,New York\nweoFk,prYGAC,hrygac@yahoocom,19,Sydney\nmZf2R,LnSBAh,lnsbah@outlook.com,18,Paris\nKIuLH,kKpddF,kkpddf@outlook.com,32,Rome\n4359Rm,LAlhya,lalhya@outlook.com,62,London\nKYQZq9yg,ZTvLpI,ztvlpi@outlook.com,27,Madrid\n9hC&UV8,wWZxgp,mwzxgp@yahoo.com,49,Madrid\nra7wsGC,DFgbNn,dfgbnn@yahoo.com,40,New York\n0=uUIzOsDN,ngPCGN,jgpcgn@gmail.com,57,Rome\nzaor8f,WXQwzY,wxqwzy@yahoo.com,27,Paris\nKTMoYqn,ZFSwLp,zfswlp@yahoo.com,57,Berlin\nOJMgD,mmJyyc,mmjyyc@yahoo.com,30,Paris\nJ49HyU,udMyki,udmyki@hotmail.com,35,Rome\nZBiXSV,gQXcjA,gqxcja@yahoo.com,68,Paris\nlP6GLm6,ljiCsY,ljicsy@gmail.com,45,Berlin\nneZAj,bBIbVF,bbibvf@gmail.com,58,London\n9uLq2KwoIr,OWXXBl,owxxbl@outlook.com,46,Sydney\nRELT7fgmnD,dplQIl,,58,New York\nHDKVi,AxLzOk,axlzok@hotmail.com,68,New York\nMp7lqou9z,SJzlEy,sjzley@gmail.com,63,London\n6rDP6BCQv,nnqyAa,nnqyaa@outlook.com,45,New York\nOyH2qjKxZ,nwWZuw,nwwzuw@yahoo.com,56,Rome\nL8DHMmE44p,MoAcMe,moacme@hotmail.com,67,Paris\nTlSmF,fPmepA,fpmepa@outlook.com,42,Rome\nE1QH9ci7,hlyLQF,hlylqf@outlook.com,41,New York\nmYOpY23,SHmAju,shmaju@hotmail.com,64,Rome\nXAEJitTlla,qrpsKE,qrpske@hotmail.com,52,Rome\ntS4XE,DoxbRW,doxbrw@outlook.com,26,Tokyo\nzGmt6Bg,JXcvKW,jxcvkw@hotmail.com,68,Madrid\n4t7td1EpM,cnxBsn,cnxbsn@outlook.com,42,Madrid\nUSYVWP9,Zhszyq,zhszyq@gmail.com,45,Berlin\nxPsBdFX,guBqHO,gubqho@gmail.com,56,Berlin\nvjs0muFgD,GlNbyN,glnbyn@hotmail.com,43,Paris\nMJjqv,lfmiGU,lfmigu@outlook.com,60,London\njZlHAbXel,YOfnFV,yofnfv@hotmail.com,38,Tokyo\nIykL8QNPN,ndBTcB,ndbtcb@gmail.com,28,Berlin\nVq7WI4,CLCYRN,clcyrn@gmail.com,25,Tokyo\nutGGulT,RdmXuh,rdmxuh@yahoo.com,68,Rome\nFQeos5,aMlzfe,amlzfe@gmail.com,43,Berlin\nbJKfMUASk,RnEDLz,rnedlz@outlook.com,36,Berlin\np3GXT0,Meohff,meohff@gmail.com,27,Madrid\nTCsiyDQpIl,FdMArs,fdmars@outlook.com,63,Berlin\ncb6RRrx,ZCyfir,zcyfir@gmail.com,45,Rome\nFm7V1tR34,VJlNXN,vjlnxn@hotmail.com,32,Rome\nVY5EHZHY,EfaHWA,efahwa@outlook.com,25,New York\nEkCCjg5e9,JvowjF,jvowjf@outlook.com,68,Paris\nKVJd37LC,IzgjKS,izgjks@gmail.com,31,Paris";
            string[] databaseList = database.Split('\n');
            string[] currentData;
            bool locationLetters;
            int error;
            string id, username, email, age, location;
            Regex emailForm = new Regex("^.+@.+\\..+$");
            foreach (string dataLine in databaseList)
            {
                currentData = dataLine.Split(',');
                //Locating data
                id = currentData[0];
                username = currentData[1];
                email = currentData[2];
                age = currentData[3];
                location = currentData[4];
                location = location.Replace(" ", "");
                if (location.All(char.IsLetter) || location == null)
                {
                    locationLetters = true;
                }
                else
                {
                    locationLetters = false;
                }
                if (id.All(char.IsLetterOrDigit) && id != null && emailForm.IsMatch(email) && int.TryParse(age, out error) && locationLetters)
                {

                }
                else
                {
                    Console.Write(username[0]);
                }
            }
            Console.ReadKey();
        }
    }
}