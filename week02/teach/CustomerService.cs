/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: If the user set as '0' into CustomerService() method
        // Expected Result: The result should be 10 as default
        Console.WriteLine("Test 1");
        var numCustomers = new CustomerService(0);

        //get the max customer
        int max = numCustomers._maxSize;

        //print the max size of the Customer Service
        Console.WriteLine("The value of the _maxSize is: " + max);
        Console.WriteLine(numCustomers);
        // Defect(s) Found: I think it is right, because it accomplish the requirement when the user set <= 0 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The user can add a new customer to the queue
        // Expected Result: 
        Console.WriteLine("Test 2");
        var customerService02 = new CustomerService(6);
        Console.WriteLine("We start with: " + customerService02._queue.Count + " Customer Services in the queue");
        customerService02.AddNewCustomer();
        customerService02.AddNewCustomer();
        Console.WriteLine("We finish with: " + customerService02._queue.Count + " Customer Services in the queue");
        // Defect(s) Found: 

        Console.WriteLine("=================");
        // Test 3
        // Scenario: The user cannot add more customers than Customer Service capacity
        // Expected Result: The system arise a message when the number of customers is equal or more than Customer Service capacity
        Console.WriteLine("Test 3");
        var customerService03 = new CustomerService(3);
        customerService03.AddNewCustomer();
        customerService03.AddNewCustomer();
        customerService03.AddNewCustomer();
        customerService03.AddNewCustomer();
        Console.WriteLine(customerService03);

        // Defect(s) Found: The alert was shown when it was greater than the capacity of the queue, but it should be shown when it was equal to the capacity, to not allow more customers.

        Console.WriteLine("=================");
        // Test 4
        // Scenario: Remove the first customer from the queue.
        // Expected Result: The first customer added should be removed
        Console.WriteLine("Test 4");
        var customerService04 = new CustomerService(3);
        customerService04.AddNewCustomer();
        Console.WriteLine("The first customer added customer is: " + customerService04._queue[0]);
        customerService04.AddNewCustomer();
        customerService04.ServeCustomer();
        Console.WriteLine("The first customer was served: " + customerService04);

        // Defect(s) Found: This work fine

        Console.WriteLine("=================");
        // Test 5
        // Scenario: If the queue is empty and the user wants to serve a customer
        // Expected Result: an alert appears that you cannot serve a customer
        Console.WriteLine("Test 5");
        var customerService05 = new CustomerService(3);
        customerService05.ServeCustomer();
        Console.WriteLine(customerService05);

        // Defect(s) Found:the problem is that the curtomer serve method did not have an "if statement" to display a message that it was empty if it had no customers






    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;

    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);

        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {

        // Verify if the _queue id empty
        if (_queue.Count <= 0)
        {
            Console.WriteLine("The Queue is empty you cannot serve the customer.");
            return;
        }


        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine("Removed: " + customer);









    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {

        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}