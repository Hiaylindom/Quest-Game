using System;
using System.Threading;

namespace KP
{
    class Program
    {
        static void Main(string[] args)
        {
            int Action_;
            int GetData()
            {
                int number;
                bool Check = false;
                do
                {
                    Check = Int32.TryParse(Console.ReadLine(), out number);
                    if (Check) Console.WriteLine("");
                    else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                } while (Check != true);
                return number;
            }
            void GameOver()
            {
                Console.WriteLine("\nИГРА ОКОНЧЕНА!\nНажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
                return;
            }

            do
            {
                string Name;
                Console.WriteLine("1. Играть");
                Console.WriteLine("2. Тестирование");
                Console.WriteLine("3. Выйти");
                Action_ = GetData();
                switch (Action_)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите имя персонажа:");
                        Name = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Выберите класс:\n1. Мечник\n2. Лучник\n3. Нищий(-ая)\n");
                        Hero Player = new Hero();
                        Player.Name_ = "";
                        do
                        {
                            Action_ = GetData();
                            switch (Action_)
                            {
                                case 1:
                                    Hero Class1 = new Hero(20, 10, 15, Name, 1, 3, "Мечник");
                                    Player = new Hero(Class1);
                                    break;
                                case 2:
                                    Hero Class2 = new Hero(15, 5, 20, Name, 1, 2, "Лучник");
                                    Player = new Hero(Class2);
                                    break;
                                case 3:
                                    Hero Class3 = new Hero(10, 0, 5, Name, 1, 1, "Нищий(-ая)");
                                    Player = new Hero(Class3);
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод.Введите число от 1 до 3.");
                                    break;
                            }
                        } while (Player.Name_ == "");
                        Action_ = 0;
                        Console.WriteLine("Вы просыпаетесь в темнице и смутно помните, что было...");
                        Console.WriteLine("Ваши действия? \n1. Осмотреться.");
                        do
                        {
                            Action_ = GetData();
                            if (Action_ == 1) Console.WriteLine("Вы осматриваетесь вокруг.");
                            else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                        } while (Action_ != 1);
                        do
                        {
                            Console.WriteLine("\nВпереди себя вы видите прутья клетки, каменные стены, записку и яму в полу.");
                            Console.WriteLine("Ваши действия? \n1. Прыгнуть в яму \n2. Остаться в темнице\n3. Прочитать записку");
                            Action_ = GetData();
                            if (Action_ == 1) Console.WriteLine("Вы видите длинный тоннель. В конце виднеется тусклый свет.");
                            else if (Action_ == 2)
                            {
                                Console.WriteLine("ИГРА ОКОНЧЕНА!\nНажмите любую кнопку, чтобы выйти.");
                                Console.ReadKey();
                                return;
                            }
                            else if (Action_ == 3)
                            {
                                Console.WriteLine("В записке написано: <<Для того, кто найдет это послание: найди старика в городе Каркоза, \nон всегда сидит на лавочке центральной улицы,он укажет путь. \nКодовая фраза: Воздух наполнен переменами.>>");
                            }
                            else Console.WriteLine("Неверный ввод. Введите число от 1 до 3.");
                        } while (Action_ != 1);
                        Console.WriteLine("Ваши действия? \n1. Пойти по туннелю\n");
                        Action_ = GetData();
                        if (Action_ == 1) Console.WriteLine("Вдруг на вас выпрыгивает крыса.");
                        NPC Rat = new NPC(3, 0, 5, "Крыса", 1);
                        do
                        {
                            Console.WriteLine("Ваши действия? \n1. Сразиться с крысой\n2. Убежать");
                            Action_ = GetData();
                            if (Action_ == 1)
                            {
                                if (Player.Fight(Rat))
                                    Player.CanYouLvlUp();
                                else GameOver();
                                Action_ = 3;
                            }
                            else if (Action_ == 2) { Console.WriteLine("Вы сбегаете от крысы."); Action_ = 3; }
                            else Console.WriteLine("Неверный ввод. Введите число от 1 до 2.");
                        } while (Action_ < 3);

                        Console.WriteLine("Свет становится все ближе и ближе. И вот вы выходите наружу.\n");
                        Console.WriteLine("Яркий свет слепит вам глаза.");
                        int VisitKarkozaCounter = 0;
                        int VisitAgloeCounter = 0;
                        do
                        {
                            Console.Write("Пройдя чуть дальше вы видите развилку и указатель: Налево - Каркоза, направо - Эглоу");
                            Console.WriteLine("\n1. Пойти налево (Каркоза)\n2. Пойти направо (Эглоу)");
                            Action_ = GetData();
                            switch (Action_)
                            {
                                case 1:
                                    do
                                    {
                                        if (VisitKarkozaCounter == 0)
                                        {
                                            Console.WriteLine("Вы сворачиваете налево и идете в сторону города Каркоза\nВдруг из кустов на вас выпригвает гоблин.\n");
                                            Villain Goblin = new Villain(10, 5, 10, "Гоблин", 2);
                                            do
                                            {
                                                Console.WriteLine("- Дальше проход платный. Отдавай все, что есть или прощайся с жизнью\nВаши действия?");
                                                Console.WriteLine("1. Напасть первым.\n2. Побежать вперед\n3. Отдать все, что есть");
                                                Action_ = GetData();
                                                if (Action_ == 1)
                                                {
                                                    if (Player.Fight(Goblin)) Console.WriteLine("Одержав победу над Гоблином, вы видите, что с него выпал мешок.\nЭто мешок с монетами. Вы получаете 10 монет.");
                                                    else GameOver();
                                                    Player.Money_ += 10;
                                                    Player.CanYouLvlUp();
                                                    Action_ = 4;
                                                }
                                                else if (Action_ == 2)
                                                {
                                                    Console.WriteLine("Вы устремляетесь вперед. Вам получается оторваться от Гоблина.");
                                                    Action_ = 4;
                                                }
                                                else if (Action_ == 3) { if (Player.Money_ == 0) Console.WriteLine("- Можешь забирать, у меня все равно ничего нет!"); else Player.Money_ -= 5; Action_ = 4; }
                                                VisitKarkozaCounter++;
                                            } while (Action_ < 4);

                                            Console.WriteLine("\nВы прибываете в город Каркоза.");
                                        }
                                        Console.WriteLine("На центральной улице города виднеется несколько зданий\nВаши действия?\n");
                                        NPC Blacksmith = new NPC(10, 10, 10, "Кузнец Йорн", 5);
                                        NPC LocalCitizen = new NPC(); LocalCitizen.Name_ = "Старик";
                                        NPC Innkeeper = new NPC(5, 5, 5, "Корчмарь", 4);
                                        Console.WriteLine("1. Пойти к кузнецу\n2. Пойти в таверну\n3. Поговорить с местными жителями\n4. Уйти из города");
                                        Action_ = GetData();
                                        switch (Action_)
                                        {
                                            case 1:
                                                Console.WriteLine("Вы направляетесь в сторону кузницы. Подойдя ближе, вас встречает суровый, но достаточно приветливый взгляд мужчины.\n");
                                                Console.WriteLine("Остановив отбиваением кувалды по мечу. Он говорит:\n- Добро пожаловать в кузницу Йорна! Чем могу быть полезен?");
                                                do
                                                {
                                                    Console.WriteLine("Ваши действия?\n1. Восстановить броню\n2. Вернуться обратно на центральную улицу");
                                                    Action_ = GetData();
                                                    if (Action_ == 1)
                                                    {
                                                        Console.WriteLine("Да, без проблем, с Вас 2 монеты");
                                                        Blacksmith.RestoreEqp(Player);
                                                    }
                                                    else if (Action_ == 2) Console.WriteLine("Вы возвращаетесь обратно на центральную улицу.");
                                                    else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                } while (Action_ != 2);
                                                Console.WriteLine("Вы возвращаетесь обратно на центральную улицу.");
                                                break;
                                            case 2:
                                                Console.WriteLine("Вы направляетесь в сторону таверны. Зайдя внутрь вас встречает добрый и гостеприимный взгляд корчмаря.");
                                                Console.WriteLine("Доброго времени суток! Желаете купить провизии?\nВаши действия?\n1. Купить еду\n2. Вернуться обратно на центральную улицу");
                                                Action_ = GetData();
                                                do
                                                {
                                                    if (Action_ == 1)
                                                    {
                                                        Console.WriteLine("Да, без проблем, с Вас 1 монета");
                                                        Innkeeper.SellFood(Player);
                                                        Console.WriteLine("Съесть еду сейчас?\n1. Да\n2. Нет");
                                                        Action_ = GetData();
                                                        if (Action_ == 1) { Player.Eat(); Action_ = 3; }
                                                        else if (Action_ == 2) { Console.WriteLine("Вы возвращаетесь обратно на центральную улицу."); Action_ = 3; }
                                                        else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                    }
                                                    if (Action_ == 2)
                                                    {
                                                        Console.WriteLine("Вы возвращаетесь обратно на центральную улицу.");
                                                        Action_ = 3;
                                                    }
                                                } while (Action_ < 3);
                                                break;
                                            case 3:
                                                Console.WriteLine("Вы подходите к старику, сидящему на лавочке. И говорите: - Я ищу приключений. Мне кажется я ищу именно вас.");
                                                Console.WriteLine("- Какая прекрасная сегодня погода, а какой воздух...");
                                                Console.WriteLine("Что вы скажете старику?\n1. Да, свежо сегодня\n2. Воздух наполнен переменами\n3. Да воздух, как воздух");
                                                Action_ = GetData();
                                                if (Action_ == 2)
                                                {
                                                    Console.WriteLine("Старик посмотрел на вас и улыбнулся.\n- Тебя то я и жду, путник. Тебе нужно отправиться прямиком к королю. Прямо по этой дороге.");
                                                    Console.WriteLine("Он указал пальцем на тропу, выходящую из города и ведущая к замку, башни которого виднелись из города.");
                                                    Console.WriteLine("- Передашь это королю. Сказав это он достал маленькую деревянную фигурку дракона и отдал вам.");
                                                    Player.MainQuestItem_ = true;
                                                    VisitKarkozaCounter++;
                                                }
                                                else
                                                {
                                                    do
                                                    {
                                                        Console.WriteLine("Старик направил свой взгляд вниз и больше ничего не ответил.");
                                                        Console.WriteLine("1. Вернуться обратно на центральную улицу");
                                                        Action_ = GetData();
                                                        if (Action_ == 1) Console.WriteLine("Вы возвращаетесь обратно на центральную улицу.");
                                                        else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                    } while (Action_ != 1);
                                                }
                                                break;
                                            case 4:
                                                int VisitGoldenMountain = 0;
                                                if (VisitKarkozaCounter == 1 && !Player.MainQuestItem_) Console.WriteLine("Вы покидаете город Каркоза.");
                                                else
                                                {
                                                    Console.WriteLine("Вы отправляетесь в сторону Королевского замка.");
                                                    Console.WriteLine("Спустя некотрое время от начала пути вам на встречу выходит человек в плаще и с мечом");
                                                    NPC GoldHunter = new NPC(20, 5, 15, "Охотник за золотом", 2);
                                                    Console.WriteLine("- Ты собираешься на Золотую гору? Не думаю, что ты будешь первым.\nВаши действия?");
                                                    Console.WriteLine("1. - Что? Вы о чем?");
                                                    Console.WriteLine("2. Напасть");
                                                    do
                                                    {
                                                        Action_ = GetData();
                                                        if (Action_ == 1) { Console.WriteLine("Незнакомец достал меч из ножны и сказал:\n- Не придуряйся. Лучше защищайся"); if (!GoldHunter.Fight(Player)) Console.WriteLine(""); else GameOver(); }
                                                        if (Action_ == 2) { if (Player.Fight(GoldHunter)) Player.CanYouLvlUp(); else { GameOver(); } }
                                                        else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                    } while (!Player.Fight(GoldHunter));
                                                    int VisitCastleCounter = 0;
                                                    do
                                                    {
                                                        Console.WriteLine("Вам на пути встречается ещё одна развилка: Направо - Золотая гора, налево - Королевский замок");
                                                        Console.WriteLine("Ваши действия?\n1. Пойти направо (Золотая гора)\n2. Пойти налево (Королевский замок)");
                                                        Action_ = GetData();
                                                        switch (Action_)
                                                        {
                                                            case 1:
                                                                NPC GoldenWizard = new NPC(45, 10, 30, "Волшебник Золотой Горы", 5);
                                                                if (VisitGoldenMountain == 0)
                                                                {
                                                                    Console.WriteLine("Пройдя долгий путь, вы попадаете к крутому склону,\nкоторый нужно преодолеть, чтобы попасть на вершину.");
                                                                    NPC WhiteRat = new NPC(10, 0, 10, "Большая белая крыса", 3);
                                                                    Console.WriteLine($"Вдруг на вашем пути появляется {WhiteRat.Name_}. Кажется боя не избежать.");
                                                                    if (!WhiteRat.Fight(Player))
                                                                    {
                                                                        GameOver();
                                                                    }
                                                                    Player.CanYouLvlUp();
                                                                    Console.WriteLine("Одержав победу над огромной крысой, сквозь ветер и метель вы взбираетесь на самую вершину Золотой горы");
                                                                    Console.WriteLine("Вам на встречу выходит волшебник и говорит:\nЯ волшебник Золотой горы, с чем ты ко мне пришел?");
                                                                }
                                                                switch (VisitAgloeCounter)
                                                                {
                                                                    case 1:
                                                                        if (VisitGoldenMountain == 0)
                                                                        {
                                                                            Console.WriteLine("Ваши действия?\n1. - Что произошло в городе Эглоу?\n2. Напасть");
                                                                            do
                                                                            {
                                                                                Action_ = GetData();
                                                                                if (Action_ == 1) Console.WriteLine("");
                                                                                else if (Action_ == 2)
                                                                                {
                                                                                    Console.WriteLine("- Ты сделал неправильное решение.");
                                                                                    if (Player.Fight(GoldenWizard)) { GameOver(); }
                                                                                    else { Console.WriteLine("\nИГРА ОКОНЧЕНА!\nЛОЖНАЯ КОНЦОВКА"); Console.ReadKey(); return; }
                                                                                }
                                                                                else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                            } while (Action_ != 1 && Action_ != 2);
                                                                            Console.WriteLine("- Ох, ужасное событие. Король спалил целый город, чтобы обвинить в этом меня.");
                                                                            Console.WriteLine("Королевство в упадке, а я просто хотел помочь людям. Я вижу, что ты устал и вымотан.\nНе хочешь немного поесть?");
                                                                            Console.WriteLine("Ваши действия?\n1. - Да, с удовольствием\n2. - Нет, все хорошо");
                                                                            do
                                                                            {
                                                                                Action_ = GetData();
                                                                                if (Action_ == 1) { GoldenWizard.GiveFood(Player); Player.Eat(); }
                                                                                if (Action_ == 2) Console.WriteLine("");
                                                                                else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                            } while (Action_ != 1 && Action_ != 2);
                                                                            Console.WriteLine("После того, как вы закончили трапезу, старик сказал:\n- С этим нужно заканчивать, ты со мной?");
                                                                            Console.WriteLine("Ваши действия?\n1. - Да, так больше продолжаться не может.\n2. Могу ли я обдумать свое решение?");
                                                                            Action_ = GetData();
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Старик сидит за столом и смиренно встречает вас взглядом.\n- Теперь вы готовы отправиться?");
                                                                            Console.WriteLine("1. Да, я готов, выдвигваемся\n2. Чуть позже, у меня ещё есть пара дел");
                                                                            Action_ = GetData();
                                                                            do
                                                                            {
                                                                                if (Action_ == 1) Console.WriteLine("");
                                                                                else if (Action_ == 2) break;
                                                                                else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                            } while (Action_ != 1 && Action_ != 2);
                                                                        }
                                                                        switch (Action_)
                                                                        {
                                                                            case 1:
                                                                                Console.WriteLine("Старик взял стояющий в углу посох и сказал:\n- В путь!");
                                                                                Console.WriteLine("После этого вы направились в дорогу.");
                                                                                Thread.Sleep(2000);
                                                                                Console.WriteLine("После нескольких часов пути вы стоите перед воротами замка.");
                                                                                Console.WriteLine("Колдун применил заклинание, которого отворила ворота.\nВам открылся проход в Королевский замок.");
                                                                                Thread.Sleep(2000);
                                                                                Console.WriteLine("Вы заходите в изысканный холл, белые мраморные колонны, бархатные ковры,\nсвисающие со балконов второго этажа и пол из полированного гранита.");
                                                                                Thread.Sleep(2000);
                                                                                Console.WriteLine("На полу лежит мягчайший красный ковер, лежащий от входа к дальней стенке.\nГде стоит трон, на троне воссидает король.\nА по бокам его верные слуги");
                                                                                Villain King = new Villain(50, 15, 30, "Король двухземелья", 5);
                                                                                Console.WriteLine("Ваши действия?\n1. Напасть на короля первым.\n2. Дать колдуну сделать, что он хочет");
                                                                                Action_ = GetData();
                                                                                switch (Action_)
                                                                                {
                                                                                    case 1:
                                                                                        Console.WriteLine("- Кем бы ты ни был, тебе конец! - сказал Король");
                                                                                        if (!Player.Fight(King)) { GameOver(); }
                                                                                        else { Console.WriteLine("\nВЫ ПОБЕДИЛИ!\nИСТИННАЯ КОНЦОВКА"); Console.ReadKey(); return; }
                                                                                        break;
                                                                                    case 2:
                                                                                        Console.WriteLine("Волшебник подошел ближе к королю и начал говорить:\n- Твоей многолетней тирании Двухземелья пришел конец. Прощайся с жизнью.");
                                                                                        if (GoldenWizard.Fight(King))
                                                                                        {
                                                                                            Console.WriteLine("Волшебник прекратил бой и упал замертво.\n- Ну, что, остались мы с тобой");
                                                                                            Thread.Sleep(2000);
                                                                                            if (!King.Fight(Player)) { GameOver(); }
                                                                                            else { Console.WriteLine("\nВЫ ПОБЕДИЛИ!\nИСТИННАЯ КОНЦОВКА"); Console.ReadKey(); return; }
                                                                                        }
                                                                                        else GameOver();
                                                                                        break;
                                                                                    default:
                                                                                        Console.WriteLine("Невернный ввод. Попробуйте ещё раз.");
                                                                                        break;
                                                                                }
                                                                                break;
                                                                            case 2:
                                                                                VisitGoldenMountain = 1;
                                                                                Console.WriteLine("- Конечно можешь, но у нас не особо много времени. Возвращайся скорее.");
                                                                                break;
                                                                                
                                                                            default:
                                                                                break;
                                                                        }
                                                                        break;
                                                                    
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }
                                                                break;
                                                            case 2:
                                                                Villain King1 = new Villain(50, 15, 30, "Король двухземелья", 5);
                                                                NPC GoldenWizard1 = new NPC(45, 10, 30, "Волшебник Золотой Горы", 5);
                                                                if (VisitCastleCounter == 1)
                                                                {
                                                                    Console.WriteLine("Проход замок для вас закрыт.\nВаши действия?\n1. Вернуться к развилке");
                                                                    do
                                                                    {
                                                                        Action_ = GetData();
                                                                        if (Action_ == 1) break;
                                                                        else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                    } while (Action_ != 1);
                                                                    break;
                                                                }
                                                                do
                                                                {
                                                                    Console.WriteLine("Вы дошли до ворот замка. Часовой смотрит на вас и спрашивает:\n- Что нужно?\nВаши действия?");
                                                                    Console.WriteLine("1. - Я к королю с важным поручением\n2. - Ничего, просто стою тут (Вернуться к развилке)");
                                                                    Action_ = GetData();
                                                                    switch (Action_)
                                                                    {
                                                                        case 1:
                                                                            Console.WriteLine("Немного подумав, часовой открывает вам ворота и вы попадает внутрь.\nВы заходите в замок и направляетесь к королю");
                                                                            Console.WriteLine("Король встречает вас надменным взглядом исподлобья и говорит:\n- Ты выглядишь как кто-то, кто может мне помочь");
                                                                            if (VisitAgloeCounter == 1)
                                                                            {
                                                                                Console.WriteLine("Ваши действия?\n1. Промолчать\n2. Лучше расскажите о том, что произошло в Эглоу");
                                                                                Action_ = GetData();
                                                                                switch (Action_)
                                                                                {
                                                                                    case 1:
                                                                                        Console.WriteLine("- Молчание - знак согласия. Так вот, на горе живет волшебник, который мешает жизни моему королевству.");
                                                                                        Console.WriteLine("Помоги мне, а я помогу тебе. Финансово.\nВаши действия?");
                                                                                        Console.WriteLine("1. Принять заказ\n2. Отказаться (уйти из замка)");
                                                                                        Action_ = GetData();
                                                                                        do
                                                                                        {
                                                                                            if (Action_ == 1)
                                                                                            {
                                                                                                Console.WriteLine("Вы согласились с условиями короля и отправились в сторону Золотой горы");
                                                                                                Console.WriteLine("Пройдя долгий путь, вы попадаете к крутому склону,\nкоторый нужно преодолеть, чтобы попастьна вершину.");
                                                                                                NPC WhiteRat = new NPC(10, 0, 10, "Большая белая крыса", 3);
                                                                                                Console.WriteLine($"Вдруг на вашем пути появляется {WhiteRat.Name_}. Кажется боя не избежать.");
                                                                                                if (!WhiteRat.Fight(Player))
                                                                                                {
                                                                                                    GameOver();
                                                                                                }
                                                                                                Player.CanYouLvlUp();
                                                                                                Console.WriteLine("Одержав победу над огромной крысой, сквозь ветер и метель вы взбираетесь на самую вершину Золотой горы");
                                                                                                Console.WriteLine("Вам на встречу выходит волшебник и говорит:\nЯ волшебник Золотой горы, с чем ты ко мне пришел?");
                                                                                                Console.WriteLine("1. Напасть на волшебника");
                                                                                                do
                                                                                                {
                                                                                                    Action_ = GetData();
                                                                                                    if (Action_ == 1)
                                                                                                    {
                                                                                                        if (!Player.Fight(GoldenWizard1))
                                                                                                        {
                                                                                                            GameOver();
                                                                                                        }
                                                                                                        else
                                                                                                            Player.CanYouLvlUp();
                                                                                                        VisitGoldenMountain = 3;
                                                                                                    }
                                                                                                    else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                                                } while (Action_ != 1);
                                                                                                Thread.Sleep(2000);
                                                                                                Console.WriteLine("Вы направляетесь в сторону замка за своей наградой. Как только вы заходите внутрь на вас обрушивается град из стрел");
                                                                                                Console.WriteLine("Чудом вы уворачиваетесь от большинства и нападаете на короля.");
                                                                                                if (!Player.Fight(King1)) { GameOver(); }
                                                                                                else { { Console.WriteLine("\nИГРА ОКОНЧЕНА!\nНЕЙТРАЛЬНАЯ КОНЦОВКА"); Console.ReadKey(); return; } }
                                                                                            }
                                                                                            else if (Action_ == 2)
                                                                                            {
                                                                                                Console.WriteLine("Вы покидаете Королевский замок.");
                                                                                                VisitCastleCounter = 1;
                                                                                                break;
                                                                                            }
                                                                                            else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                                        } while (Action_ != 1 && Action_ != 2);
                                                                                        break;
                                                                                    case 2:
                                                                                        Console.WriteLine("Король разозленно посмотрел на вас.\n- Стража!\nВаши действия?");
                                                                                        Console.WriteLine("1. Напасть на короля\n2. Сбежать");
                                                                                        do
                                                                                        {
                                                                                            Action_ = GetData();
                                                                                            if (Action_ == 1)
                                                                                            {
                                                                                                if (!Player.Fight(King1)) GameOver();
                                                                                                else { Console.WriteLine("\nВЫ ПОБЕДИЛИ!\nИСТИННАЯ КОНЦОВКА"); Console.ReadKey(); return; }
                                                                                            }
                                                                                            else if (Action_ == 2)
                                                                                            {
                                                                                                VisitCastleCounter = 1;
                                                                                                break;
                                                                                            }
                                                                                            else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                                        } while (Action_ != 1 && Action_ != 2);
                                                                                        break;
                                                                                    default:
                                                                                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                                                        break;
                                                                                }
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            break;
                                                                        default:
                                                                            Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                                                                            break;
                                                                    }
                                                                } while (Action_ != 1 && Action_ != 2);
                                                                break;
                                                        default:
                                                            Console.WriteLine("Неверный ввод. Попробуйте ещё раз");
                                                            break;
                                                    }
                                                    } while (true); 
                                                    break;
                                                    
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    } while (Action_ != 4);
                                    Action_ = 0;
                                    break;
                                case 2:
                                    if(VisitAgloeCounter == 0)
                                    {
                                        Console.WriteLine("Вы прибываете в город Эглоу. Везде следы побоища, сгоревшие дома и много трупов. \nВы увидели как-то кто-то испуганно смотрит на вас из окна разрушенного дома.");
                                        Console.WriteLine("Ваши действия?");
                                        Console.WriteLine("1. - Я не причиню вам вреда. Что здесь произошло?");
                                        Console.WriteLine("2. Напасть");
                                        Console.WriteLine("3. Уйти из города");
                                        NPC AgloeCitizen = new NPC(); AgloeCitizen.Name_ = "Местный житель";
                                        Action_ = GetData();
                                        switch (Action_)
                                        {
                                            case 1:
                                                Console.WriteLine("Через некоторое время мирный житель выходит к вам и говорит:\n- Король напал на наш город. Не знаю точно зачем, но мало кто остался жив.");
                                                Console.WriteLine("Я спрятался, как только это все началось и к счастью меня не нашли.\nЯ слышал, как один из солдат говорил, что теперь с волшебником будет покончено.");
                                                Console.WriteLine("Что вы скажите мирному жителю?\n1.- Кто такой этот волшебник?\n2.- Спасибо, что рассказали мне это (Уйти из Эглоу)");
                                                Action_ = GetData();
                                                if (Action_ == 1)
                                                {
                                                    Console.WriteLine("- Это мудрец, который живет на вершине Золотой горы. Он помогал нашей деревне с провизией, а также избавил нас от засухи.");
                                                    Console.WriteLine("1. - Спасибо, что рассказали мне это (Уйти из Эглоу)");
                                                    VisitAgloeCounter = 1;
                                                    Action_ = GetData();
                                                    if (Action_ == 1) Console.WriteLine("Вы покидаете город Эглоу.");
                                                }
                                                if (Action_ == 2) { Console.WriteLine("Вы покидаете город Эглоу."); }
                                                break;
                                            case 2:
                                                Player.Fight(AgloeCitizen);
                                                Player.CanYouLvlUp();
                                                VisitAgloeCounter = 2;
                                                Console.WriteLine("\nВаши действия?\n1. Покинуть Эглоу");
                                                do
                                                {
                                                    Action_ = GetData();
                                                    if (Action_ == 1) Console.WriteLine("Вы покидаете город Эглоу.");
                                                    else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                } while (Action_ != 1 && Action_ != 2);
                                                break;
                                            default:
                                                Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("- Я узнал все, что мог здесь. Нужно идти дальше.\nВаши действия?\n1. Покинуть Эглоу");
                                        do
                                        {
                                            Action_ = GetData();
                                            if (Action_ == 1) Console.WriteLine("Вы покидаете город Эглоу.");
                                            else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                                        } while (Action_ != 1);
                                    }
                                 
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод. Введите число от 1 до 2.");
                                    break;
                            }
                        } while (Player.MainQuestItem_ != true && Action_ != 4);


                        break;
                    case 2:
                        Testing();
                        void Testing()
                        {
                            int TestCounter = 0;
                            // Test 1
                            Hero Hero1 = new Hero();
                            Hero Hero2 = new Hero();
                            NPC NPC = new NPC();
                            Villain g = new Villain();
                            Hero1.Money_ += 3;
                            NPC.UpgradeWeapon(Hero1);
                            Hero2.Damage_ += 5;
                            if (Hero1.Damage_ == Hero2.Damage_) TestCounter++;
                            // Test 2
                            Hero1.UpgradeLevel();
                            Hero2.UpgradeLevel();
                            if (Hero1.HP == Hero2.HP) TestCounter++;
                            // Test 3
                            if (Hero1.Fight(g) && Hero2.Fight(NPC)) TestCounter++;
                            // Test 4
                            Hero1.Money_ += 10;
                            NPC.SellFood(Hero1);
                            Hero1.Eat();
                            if (Hero1.HP == 38) TestCounter++;
                            Console.WriteLine($"Успешно проведено {TestCounter} из 4 тестов");
                        }
                        do
                        {
                            Console.WriteLine("\n1. Провести тесты ещё раз\n2. Выйти в главное меню");
                            Action_ = GetData();
                            if (Action_ == 1) Testing();
                            else if (Action_ == 2) {}
                            else Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                        } while (Action_ != 2);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Введите число от 1 до 3.");
                        break;
                } while (Action_ != 3) ;
            } while (Action_ != 3);
            Environment.Exit(0);
        }




    }
    abstract class Character
    {
        protected int HealthPoints;
        protected int Armor;
        protected int Damage;
        public string Name;
        protected int Level;

        public Character()
        {
            this.HealthPoints = 10;
            this.Armor = 10;
            this.Damage = 10;
            this.Name = "Персонаж";
            this.Level = 1;
        }
        public virtual bool Fight(Character Hero)
        {
            bool Result = false;
            Console.WriteLine($"Началась битва между {this.Name_} и {Hero.Name_}");
            do
            {
                this.DealDamage(Hero);
                Hero.DealDamage(this);
            } while (this.HP >= 0 && Hero.HP >= 0);
            if (this.HealthPoints <= 0)
            {
                Console.WriteLine($"{Hero.Name_} одолел {this.Name_}.");
                Result = true;
            }
            else Console.WriteLine($"{this.Name_} одолел {Hero.Name_}.");
            return Result;
        }
        public abstract void DealDamage(Character Hero);
        public int Damage_ { get { return Damage; } set { Damage = value; } }
        public int HP
        {
            get { return HealthPoints; }
            set { HealthPoints = value; }
        }
        public int Protection
        {
            get { return Armor; }
            set { Armor = value; }
        }
        public string Name_
        {
            get { return Name; }
            set { Name = value; }
        }
        ~Character() { Console.WriteLine($"{this.Name_} умер или пропал без вести."); }
    }
    class Hero : Character
    {
        protected int Energy;
        private int Exp;
        private static int ExpForLvlUp = 5;
        private int EnergyNeeded = 1;
        private static int UprageGrowth = 3;
        private static int MaxLevel = 10;
        public string Class;
        protected int Money;
        protected int Food = 0;
        protected bool MainQuestItem = false;
        public Hero()
        {
            this.HealthPoints = 25;
            this.Armor = 10;
            this.Damage = 15;
            this.Name = "Герой";
            this.Level = 1;
            this.Energy = 2;
            this.Class = "Без класса";
            this.Exp = 0;
            this.Money = 0;
        }
        public Hero(int HealthPoints, int Armor, int Damage, string Name, int Level, int Energy, string Class)
        {
            this.HealthPoints = HealthPoints;
            this.Armor = Armor;
            this.Damage = Damage;
            this.Name = Name;
            this.Level = Level;
            this.Energy = Energy;
            this.Class = Class;
            this.Money = 0;
        }
        public Hero(Hero Hero)
        {
            this.HealthPoints = Hero.HealthPoints;
            this.Armor = Hero.Armor;
            this.Damage = Hero.Damage;
            this.Name = Hero.Name;
            this.Level = Hero.Level;
            this.Energy = Hero.Energy;
            this.Class = Hero.Class;
            this.Exp = Hero.Exp;
            this.Money = Hero.Money;
        }
        public override bool Fight(Character Hero)
        {
            int RoundCounter = 0;
            bool Result = false;
            Console.WriteLine($"Началась битва между {this.Name_} и {Hero.Name_}");
            do
            {
                this.DealDamage(Hero);
                Hero.DealDamage(this);
                RoundCounter++;
            } while (this.HP >= 0 && Hero.HP >= 0);
            if (this.HealthPoints <= 0)
            {
                Console.WriteLine($"{Hero.Name_} одолел {this.Name_}.");
            }
            else
            {
                Console.WriteLine($"{this.Name_} одолел {Hero.Name_}.");
                Exp += RoundCounter * Hero.Damage_;
                Result = true;
            }
            return Result;
        }
        public void CanYouLvlUp()
        {
            if (Exp >= ExpForLvlUp)
            {
                this.UpgradeLevel();
                Exp -= ExpForLvlUp;
            }
            else return;
        }
        public void UpgradeLevel()
        {
            if (Level == MaxLevel)
            {
                Console.WriteLine($"Персонаж {Name} имеет максимальный уровень.");
                return;
            }
            else
            {
                if (Energy >= EnergyNeeded)
                {
                    Console.WriteLine($"{Name} тренируется.");
                    Energy -= EnergyNeeded;
                    HealthPoints += UprageGrowth;
                    Damage += UprageGrowth * 2;
                    EnergyNeeded += 2;
                    Level++;
                    Console.WriteLine($"{Name} повышает уровень и теперь имеет характеристики:");
                    Console.WriteLine($"Уровень: {Level}");
                    Console.WriteLine($"Количество здоровья: {HealthPoints}");
                    Console.WriteLine($"Урон: {Damage}");
                }
                else Console.WriteLine("У вас не хватает энергии, чтобы повысить уровень.");
            }
        }
        public void Eat()
        {
            if (Food >= 1)
            {
                Food--;
                HealthPoints += 10;
                Energy += 2;
                Console.WriteLine($"{this.Name_} съел еду и восстановил 10 здоровья. Теперь у него {HealthPoints} здоровья.");
            }
            else Console.WriteLine("Нет еды, чтобы поесть.");
        }
        public override void DealDamage(Character Hero)
        {
            if (Hero.Protection <= 0) Hero.HP -= this.Damage;
            else Hero.Protection -= this.Damage;
            Console.WriteLine($"{this.Name_} атаковал {Hero.Name_} и нанес {this.Damage} урона.");
        }

        public static Hero operator +(Hero Hero, Hero Hero1)
        {
            Hero.HP += Hero1.HP;
            Hero.Damage += Hero1.Damage;
            Hero.Armor += Hero1.Armor;
            Hero.Energy += Hero1.Energy;
            Hero.Exp += Hero1.Exp;
            Hero.Money += Hero1.Money;
            return Hero;
        }

        public static Hero operator ++(Hero Hero)
        {
            Hero.UpgradeLevel();
            Hero.Money += 3;
            return Hero;
        }

        public static bool operator &(Hero Hero, Hero Hero1)
        {
            int Temp = 0, Temp1 = 0;
            if (Hero.Level > Hero1.Level) Temp++; else Temp1++;
            if (Hero.HP > Hero1.HP) Temp++; else Temp1++;
            if (Hero.Protection > Hero1.Protection) Temp++; else Temp1++;
            if (Hero.Damage > Hero1.Damage) Temp++; else Temp1++;
            if (Temp > Temp1) return true; else return false;
        }
        public int Food_ { get { return Food; } set { Food = value; } }
        public int Money_ { get { return Money; } set { Money = value; } }
        public int GetEnergy { get { return Energy; } }
        public bool MainQuestItem_ { get { return MainQuestItem; } set { MainQuestItem = value; } }
        ~Hero() { Console.WriteLine($"{this.Name_} умер или пропал без вести."); }
    }
    class Villain : Character
    {
        protected double MagicDamage;
        public Villain()
        {
            this.HealthPoints = 10;
            this.Armor = 0;
            this.MagicDamage = 10;
            this.Name = "Злодей";
            this.Level = 1;
        }
        public Villain(int HealthPoints, int Armor, double MagicDamage, string Name, int Level)
        {
            this.HealthPoints = HealthPoints;
            this.Armor = Armor;
            this.MagicDamage = MagicDamage;
            this.Name = Name;
            this.Level = Level;
        }
        public override void DealDamage(Character Hero)
        {
            double HP;
            if (Hero.Protection <= 0)
            {
                HP = this.MagicDamage * 1.2;
                Hero.HP -= Convert.ToInt16(HP);
            }
            else Hero.Protection -= Convert.ToInt32(0.5 * this.MagicDamage);
            Console.WriteLine($"{this.Name_} атаковал магией {Hero.Name_} и нанес {this.Damage} магического урона.");
        }
        ~Villain() { Console.WriteLine($"{this.Name_} умер или пропал без вести."); }
    }
    class NPC : Character
    {
        private static double NPCRatio = 0.5;
        public NPC()
        {
            this.HealthPoints = 10;
            this.Armor = 10;
            this.Damage = 10;
            this.Name = "NPC";
            this.Level = 1;
        }
        public NPC(int HealthPoints, int Armor, int Damage, string Name, int Level)
        {
            this.HealthPoints = HealthPoints;
            this.Armor = Armor;
            this.Damage = Damage;
            this.Name = Name;
            this.Level = Level;
        }
        public override void DealDamage(Character Hero)
        {
            double HP;
            if (Hero.Protection <= 0)
            {
                HP = Convert.ToDouble(this.Damage) * NPCRatio;
                Hero.HP -= Convert.ToInt16(HP);
            }
            else Hero.Protection -= this.Damage;
            Console.WriteLine($"{this.Name_} атаковал {Hero.Name_} и нанес {this.Damage} урона.");
        }
        public void UpgradeWeapon(Hero Hero)
        {
            if (Hero.Money_ >= 3)
            {
                Hero.Money_ -= 3;
                Hero.Damage_ += 5;
            }
        }

        public void RestoreEqp(Hero Hero)
        {
            if (Hero.Protection < 15)
            {
                if (Hero.Money_ >= 2)
                {
                    Hero.Money_ -= 2;
                    Hero.Protection = 15;
                    Console.WriteLine($"Броня игрока {Hero.Name} была восстановлена до {Hero.Protection}.");
                }
                else Console.WriteLine("Не хватает денег на восстановление брони.");
            }
            else Console.WriteLine("Восстановления обмундирования не требуется");

        }
        public void SellFood(Hero Hero)
        {
            if (Hero.Money_ >= 1)
            {
                Hero.Money_ -= 2;
                this.GiveFood(Hero);
            }
        }
        public void GiveFood(Hero Hero)
        {
            Hero.Food_++;
        }

        ~NPC() { Console.WriteLine($"{this.Name_} умер или пропал без вести."); }
    }
}