namespace WileyHomeWork.VersionIncrementer
{
    internal class Version

    {
        internal int FirstVersionNo { get; set; }
        internal int SecondVersionNo { get; set; }
        internal int ThirdVersionNo { get; set; }
        internal int FourthVersionNo { get; set; }

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
