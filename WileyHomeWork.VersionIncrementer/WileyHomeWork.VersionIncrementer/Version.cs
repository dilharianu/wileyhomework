namespace WileyHomeWork.VersionIncrementer
{
    public class Version

    {
        public int FirstVersionNo { get; set; }
        public int SecondVersionNo { get; set; }
        public int ThirdVersionNo { get; set; }
        public int FourthVersionNo { get; set; }

        public Version(int first, int second, int third, int fouth)
        {
            this.FirstVersionNo = first;
            this.SecondVersionNo = second;
            this.ThirdVersionNo = third;
            this.FourthVersionNo = fouth;
        }

        public override string ToString() 
        {
            return $"{this.FirstVersionNo}.{this.SecondVersionNo}.{this.ThirdVersionNo}.{this.FourthVersionNo}";
        }
    }
}
