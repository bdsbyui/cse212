/*
 * CSE212 
 * (c) BYU-Idaho
 * 04-Teach - Problem 2
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
 * to post it online.  Storage into a personal and private repository (e.g. private
 * GitHub repository, unshared Google Drive folder) is acceptable.
 *
 */

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:

        // Test Cases

        // // Test 1
        // // Scenario: Instance of CustomerService with invalid maxSize argument.
        // // Expected Result: _maxSize = 10
        // Console.WriteLine("Test 1: CustomerService(-10)");
        // var csSizeInvalid = new CustomerService(-10);
        // Console.WriteLine(csSizeInvalid);

        // // Defect(s) Found: 

        // Console.WriteLine("=================");

        // // Test 2
        // // Scenario: Instance of CustomerService with maxSize 5.
        // // Expected Result: _maxSize = 5
        // Console.WriteLine("Test 2: CustomerService(5)");
        // var csSizeFive = new CustomerService(5);
        // Console.WriteLine(csSizeFive);

        // // Defect(s) Found: 

        // Console.WriteLine("=================");

        // // Test 3
        // // Scenario: Instance of CustomerService with maxSize 100.
        // // Expected Result: _maxSize = 100
        // Console.WriteLine("Test 3: CustomerService(100)");
        // var csSizeHundred = new CustomerService(100);
        // Console.WriteLine(csSizeHundred);

        // // Defect(s) Found: 

        // Console.WriteLine("=================");

        // // Test 4
        // // Scenario: Add New customer
        // // Expected Result: enqueued
        // Console.WriteLine("Test 4: Add One Customer");
        // var csAddNew = new CustomerService(5);
        // csAddNew.AddNewCustomer();
        // Console.WriteLine(csAddNew);

        // // Defect(s) Found: 

        // Console.WriteLine("=================");

        // Test 5
        // Scenario: Full
        // Expected Result: error
        // Console.WriteLine("Test 5: Full queue");
        // var csFullQueue = new CustomerService(2);
        // csFullQueue.AddNewCustomer();
        // csFullQueue.AddNewCustomer();
        // csFullQueue.AddNewCustomer();
        // Console.WriteLine(csFullQueue);

        // Defect(s) Found: 

        // Console.WriteLine("=================");

        // // Test 6
        // // Scenario: Dequeue
        // // Expected Result: dequeue
        // Console.WriteLine("Test 6: Dequeue");
        // var csDequeue = new CustomerService(2);
        // csDequeue.AddNewCustomer();
        // csDequeue.AddNewCustomer();
        // csDequeue.ServeCustomer();
        // Console.WriteLine(csDequeue);

        // // Defect(s) Found: 

        // Console.WriteLine("=================");

        // Test 7
        // Scenario: Serve Empty
        // Expected Result: error
        Console.WriteLine("Test 7: Emptied queue");
        var csDequeue = new CustomerService(2);
        csDequeue.AddNewCustomer();
        csDequeue.AddNewCustomer();
        csDequeue.ServeCustomer();
        csDequeue.ServeCustomer();
        csDequeue.ServeCustomer();
        Console.WriteLine(csDequeue);

        // Defect(s) Found: 

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
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
    private void ServeCustomer() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}