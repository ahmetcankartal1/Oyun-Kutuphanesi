namespace oyunkutuphanesi.kartoyunu
{
    public abstract class Zorluk
    {
        public abstract int KartSayisi { get; }
    }

    public class Kolay : Zorluk
    {
        public override int KartSayisi => 4;
    }

    public class Orta : Zorluk
    {
        public override int KartSayisi => 8;
    }

    public class Zor : Zorluk
    {
        public override int KartSayisi => 16;
    }
}
