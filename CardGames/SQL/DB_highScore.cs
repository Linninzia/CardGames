namespace DBDomain
{
    class DB_highScore
    {
        public int Id { get; set; }
        public int Points { get; set; }

        public DB_player Player { get; set; }
    }
}
