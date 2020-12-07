 class passportHelpers
    {


        public static int PassToRow(string pass)
        {
            if (pass.Length == 10) pass = pass.Substring(0, 7);
            if (pass.Length != 7) return -1;
            pass = pass.Replace('F', '0').Replace('B', '1');
            return Convert.ToInt32(pass, 2);

        }

        public static string RowToPass(int row)
        {
            if (row > 127) return "";
            return Convert.ToString(row, 2).PadLeft(7).Replace('0', 'F').Replace('1', 'B');
        }

        public static int PassToSeat(string pass)
        {
            if (pass.Length == 10) pass = pass.Substring(7, 3);
            if (pass.Length != 3) return -1;
            pass = pass.Replace('L', '0').Replace('R', '1');
            return Convert.ToInt32(pass, 2);
        }

        public static string SeatToPass(int seat)
        {
            if (seat > 7) return "";
            return Convert.ToString(seat, 2).PadLeft(3).Replace('0', 'L').Replace('1', 'R');
        }

        public static int PassToSeatID(string pass)
        {
            if (pass.Length != 10) return -1;
            int seatID = PassToRow(pass) * 8 + PassToSeat(pass);
            return seatID;
        }

        public static string SeatIDToPass(int SeatID)
        {
            int seat = SeatID % 8;
            int row = SeatID / 8;
            return RowToPass(row) + SeatToPass(seat);


        }
    }