using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextRPG_V2
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    internal class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = new Player();
        private Monster monster = new Monster();
        private Random rand = new Random();

        public GameMode GetGameMode() { return mode; }

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void PrintNowBothHP()
        {
            Console.WriteLine("현재 플레이어의 체력: {0}", player.GetHp());
            Console.WriteLine("현재 몬스터의 체력: {0}", monster.GetHp());
            Console.WriteLine("---------------------------");
        }

        private void PrintStat()
        {
            Console.WriteLine($"체력 : {player.GetHp()}");
            Console.WriteLine($"공격력 : {player.GetPower()}");
            Console.WriteLine("스텟 분배가 완료되었습니다!");
            Console.WriteLine("---------------------------");
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요!\n[1] 기사\n[2] 궁수\n[3] 마법사");
            Console.WriteLine("[4] 게임 종료 (직업 아님)");
            Console.WriteLine("---------------------------");
            string? input = Console.ReadLine();
            Console.WriteLine("---------------------------");
            switch (input)
            {
                case "1":
                    player = new Knight();
                    PrintStat();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    PrintStat();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    PrintStat();
                    mode = GameMode.Town;
                    break;
                case "4":
                    mode = GameMode.None;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장하셨습니다!");
            Console.WriteLine("[1] 필드로 들어가기");
            Console.WriteLine("[2] 현재 체력 확인");
            Console.WriteLine("[3] 로비로 돌아가기");
            Console.WriteLine("---------------------------");
            string? input = Console.ReadLine();
            Console.WriteLine("---------------------------");
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    Console.WriteLine($"현재 체력은 {player.GetHp()} 입니다");
                    Console.WriteLine("---------------------------");
                    break;
                case "3":
                    mode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장하셨습니다!");

            CreateRandomMonster();
            while (true)
            {
                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 마을로 도망치기 (50%)");
                Console.WriteLine("---------------------------");
                string? input = Console.ReadLine();
                Console.WriteLine("---------------------------");

                if (input == "1")
                {
                    ProcessFight();
                    break;
                }
                else if (input == "2")
                {
                    TryEscape();
                    break;
                }
            }
        }

        private void ProcessFight()
        {
            Console.WriteLine("전투를 시작합니다!");
            Console.WriteLine("---------------------------");
            while (true)
            {
                int damage = player.GetPower();
                monster.OnDamaged(damage);
                Console.WriteLine("플레이어의 공격이 명중했습니다!");
                if (monster.IsDead() == true)
                {
                    mode = GameMode.Town;
                    PrintNowBothHP();
                    Console.WriteLine("전투에서 승리하셨습니다!");
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine("---------------------------");
                    break;
                }

                damage = monster.GetPower();
                player.OnDamaged(damage);
                Console.WriteLine("몬스터가 반격을 성공했습니다!");
                if (player.IsDead() == true)
                {
                    mode = GameMode.Lobby;
                    PrintNowBothHP();
                    Console.WriteLine("전투에서 패배하셨습니다");
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine("---------------------------");
                    break;
                }
                PrintNowBothHP();
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 스폰되었습니다!");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오크가 스폰되었습니다!");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    break;
            }
        }

        private void TryEscape()
        {
            int randnum = rand.Next(0, 2);

            if (randnum == 0) // 50%로 도망 실패
            {
                Console.WriteLine("도망치는데 실패했습니다!");
                Console.WriteLine("---------------------------");
                ProcessFight(); // 싸움 붙이기
            }
            else if (randnum == 1) // 50%로 도망 성공
            {
                mode = GameMode.Town;
                Console.WriteLine("도망치는데 성공했습니다!");
                Console.WriteLine("---------------------------");
            }
        }
    }
}
