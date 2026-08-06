using EasyTask.Pages;

namespace EasyTask.Class.YesOrNoClass
{
    class CallToTwoWayYesNo
    {
        public static int startYesOrNoWindowProcess(string Title,string subtitle,string buttonContent1,string buttonContent2)
        {

            TwoWayYesNo twoWayYesNo = new TwoWayYesNo();
            twoWayYesNo.SetValuesOfTitles(Title,subtitle,buttonContent1,buttonContent2);
            twoWayYesNo.ShowDialog();
            return twoWayYesNo.FinalValueOfYesOrNo;
        }
        public static int startYesOrNoWindowProcess(string Title, string subtitle, string buttonContent1, string buttonContent2, int Priority)
        {

            TwoWayYesNo twoWayYesNo = new TwoWayYesNo();

            twoWayYesNo.SetValuesOfTitles(Title, subtitle, buttonContent1, buttonContent2,Priority); 
            twoWayYesNo.ShowDialog();
            return twoWayYesNo.FinalValueOfYesOrNo;
        }
    }
}
