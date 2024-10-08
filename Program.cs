using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    private string name;
    private decimal salary;

    public Employee(string name, decimal salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
                salary = value;
            else
                throw new ArgumentException("Зарплата не может быть отрицательной.");
        }
    }

    public static Employee operator +(Employee emp, decimal amount)
    {
        return new Employee(emp.name, emp.salary + amount);
    }

    public static Employee operator -(Employee emp, decimal amount)
    {
        if (emp.salary - amount >= 0)
            return new Employee(emp.name, emp.salary - amount);
        else
            throw new ArgumentException("Зарплата не может быть меньше нуля.");
    }
    // ==  и  != -> надо перегружать вместе если убрать хоть один то будет ошибка 
    //==============================================================================
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        return emp1.salary == emp2.salary;
    }
   
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }
    //==============================================================================
    // < и > -> надо перегружать вместе если убрать хоть один то будет ошибка 
    //==============================================================================
    public static bool operator >(Employee emp1, Employee emp2)
    {
        return emp1.salary > emp2.salary;
    }

    public static bool operator <(Employee emp1, Employee emp2)
    {
        return emp1.salary < emp2.salary;
    }
    //==============================================================================

    public static decimal operator +(Employee emp1, Employee emp2)
    {
        return emp1.salary + emp2.salary ;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Employee))
            return false;

        Employee other = (Employee)obj;
        return this.salary == other.salary;
    }

    public override int GetHashCode()
    {
        return salary.GetHashCode();
    }

    public override string ToString()
    {
        return $"Сотрудник: {name}, Зарплата  : {salary}$";
    }
}

class City
{
    private string name;
    private int population;

    public City(string name, int population)
    {
        this.name = name;
        this.population = population;
    }

    public int Population
    {
        get { return population; }
        set
        {
            if (value >= 0)
                population = value;
            else
                throw new ArgumentException("Число жителей не может быть отрицательным.");
        }
    }

    public static City operator +(City city, int amount)
    {
        return new City(city.name, city.population + amount);
    }

    public static City operator -(City city, int amount)
    {
        if (city.population - amount >= 0)
            return new City(city.name, city.population - amount);
        else
            throw new ArgumentException("Население не может быть меньше нуля.");
    }

    public static bool operator ==(City city1, City city2)
    {
        return city1.population == city2.population;
    }

    public static bool operator !=(City city1, City city2)
    {
        return !(city1 == city2);
    }

    public static bool operator >(City city1, City city2)
    {
        return city1.population > city2.population;
    }

    public static bool operator <(City city1, City city2)
    {
        return city1.population < city2.population;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is City))
            return false;

        City other = (City)obj;
        return this.population == other.population;
    }

    public override int GetHashCode()
    {
        return population.GetHashCode();
    }

    public override string ToString()
    {
        return $"Город: {name} Население: {population}";
    }
}

class CreditCard
{
    public string cardNumber;
    public int cvc;
    public decimal balance;

    public CreditCard(string cardNumber, int cvc, decimal balance)
    {
        this.cardNumber = cardNumber;
        this.cvc = cvc;
        this.balance = balance;
    }

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
                balance = value;
            else
                throw new ArgumentException("Баланс не может быть отрицательным.");
        }
    }

    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        return new CreditCard(card.cardNumber, card.cvc, card.balance + amount);
    }

    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        if (card.balance - amount >= 0)
            return new CreditCard(card.cardNumber, card.cvc, card.balance - amount);
        else
            throw new ArgumentException("Баланс не может быть меньше нуля.");
    }

    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        return card1.cvc == card2.cvc;
    }

    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        return card1.balance > card2.balance;
    }

    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        return card1.balance < card2.balance;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is CreditCard))
            return false;

        CreditCard other = (CreditCard)obj;
        return this.cvc == other.cvc;
    }

    public override int GetHashCode()
    {
        return cvc.GetHashCode();
    }

    public override string ToString()
    {
        return $"Карта: {cardNumber}, CVC: {cvc}, Баланс: {balance}";
    }
}

class Program
{
    public static void Line() => Console.WriteLine("==========================================================================================================");

    static void Main()
    {
        //Задание 1
        //Создайте и опишите класс «Сотрудник».
        //Добавьте в уже созданный класс информацию о заработной плате работника.
        //Выполните перегрузку
        //+(для увеличения зарплаты на указанное количество),
        //– (для уменьшения зарплаты на указанное количество),
        //== (проверка на равенство зарплат работников),
        //< и > (проверка на меньшее или большее количество зарплат работников),
        //!= и Equals.Используйте механизм свойств полей класса.

        //Задание 2
        //Создайте и опишите класс «Город».
        //Выполните перегрузку
        //+(для увеличения количества жителей на указанное количество),
        //– (для уменьшения количества жителей на указанное количество),
        //== (проверка на равенство двух городов по количеству жителей),
        //< и > (проверка на меньшее или большее количество жителей),
        //!= и Equals.Используйте механизм свойств полей класса.

        //Задание 3
        //Создайте и опишите класс «Кредитная карта».
        //Добавьте к уже созданному классу информацию о сумме денег на карте.
        //Выполните перегрузку
        //+(для увеличения суммы денег на указанное количество),
        //– (для уменьшения суммы денег на указанное количество),
        //== (проверка на равенство CVC кода),
        //< и > (проверка на меньшее или большее количество суммы денег),
        //!= и Equals.

        try
        {
            // Задание 1: Сотрудник
            Line();
            Console.WriteLine("Dz_1");
            Line();
            string[] employee_name = new string[] { "Иван", "Анна" };
            int[] salary = new int[] { 500, 600 };
            int[] salary_plus  = new int[] { 50 };
            int[] salary_minus = new int[] { 20 };

            Employee emp1 = new Employee(employee_name[0], salary[0]);
            Employee emp2 = new Employee(employee_name[1], salary[1]);
            Console.WriteLine(emp1.ToString());
            Console.WriteLine(emp2.ToString());
            Console.WriteLine($"{employee_name[0]}     : +{salary_plus[0]}$");
            emp1 += salary_plus[0];//+
            Console.WriteLine($"{employee_name[1]}     : -{salary_minus[0]}$");
            emp2 -= salary_plus[0];//-
            Console.WriteLine(emp1.ToString());
            Console.WriteLine(emp2.ToString());
            Console.WriteLine($"Зарплаты ({employee_name[0]} {employee_name[1]}) равны?: {emp1 == emp2}"); // != и ==     ??? 
            Line();


            // Задание 2: Город
            Console.WriteLine("Dz_2");
            Line();
            var city_name = new string[] { "Киев", "Львов" };
            var city_population = new int[] { 2950000, 721301 };
            int city_population_plus = 100000;
            int city_population_minus = 50000;

            City city1 = new City($"{city_name[0]}  :", city_population[0]);
            City city2 = new City($"{city_name[1]} :",  city_population[1]);
            Console.WriteLine(city1);
            Console.WriteLine(city2);
            Console.WriteLine($"{city_name[0]}         : +{city_population_plus}");
            Console.WriteLine($"{city_name[1]}        : -{city_population_minus}");
            city1 += city_population_plus;//+
            city2 -= city_population_minus;//-
            Console.WriteLine(city1);
            Console.WriteLine(city2);
            Console.WriteLine($"Население городов равно?: {city1 == city2}");// != и ==     ??? 
            Line();


            // Задание 3: Кредитная карта
            Console.WriteLine("Dz_3");
            Line();
            var cardNumber = new string[] { "1234 5678 9123 4567", "9876 5432 1098 7654" };
            var cvc = new int[] { 123, 123 };
            var balance = new decimal[] { 1000, 500 };
            decimal plus_balance_cart  = 200;
            decimal minus_balance_cart = 100;

            CreditCard card1 = new CreditCard(cardNumber[0], cvc[0], balance[0]);
            CreditCard card2 = new CreditCard(cardNumber[1], cvc[1], balance[1]);
            Console.WriteLine(card1);
            Console.WriteLine(card2);
            Console.WriteLine();

            Console.WriteLine($"Карта: {card1.cardNumber}     :+{plus_balance_cart}$");
            Console.WriteLine($"Карта: {card2.cardNumber}     :-{minus_balance_cart}$");
            card1 += plus_balance_cart;//+
            card2 -= minus_balance_cart;//-
            Console.WriteLine();

            Console.WriteLine(card1);
            Console.WriteLine(card2);
            Console.WriteLine($"CVC код одинаковый?            : {card1 == card2}"); // != и ==     ??? 
            Line();


        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message );
            Console.ReadLine();
            
        }
    }
}
