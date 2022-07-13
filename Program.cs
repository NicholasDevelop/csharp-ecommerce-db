// See https://aka.ms/new-console-template for more information
/*Si realizzi un prototipo di un e-commerce con approccio code-first usando Entity Framework seguendo lo schema allegato.
Si consideri la possibilità di poter verificare la bontà del prototipo eseguendo alcune operazioni di CRUD sul sistema:
1 - inserire almeno 3 prodotti diversi
2 - inserire almeno 5 ordini su almeno 2 utenti diversi
3 - recuperare la lista di tutti gli ordini effettuati da un cliente
4 - modificare l’ordine di un cliente
5 - cancellare un ordine di un cliente
6 - cancellare un prodotto su cui è attivo almeno un ordine */


/*GESTIONE MENU*/
Console.WriteLine("**** MENU E-COMMERCE ****");
Console.WriteLine("Scegliere cosa si vuole fare");
Console.WriteLine("1- Inserire prodotti");
Console.WriteLine("2- Registrazione utente");
Console.WriteLine("3- Menu ordini");
Console.WriteLine("4- Menu recupera lista ordini di un cliente");
Console.WriteLine("5- Menu modifica ordini di un cliente");
Console.WriteLine("6- Menu elimina ordine di un cliente");
Console.WriteLine("0- Esci");


int menuInput = Int32.Parse(Console.ReadLine());

switch (menuInput)
{
    case 1:
        Console.WriteLine("**** MENU AGGIUNGI PRODOTTO ****");
        using (EcommerceContext db = new EcommerceContext())
        {
            Console.WriteLine("Inserire nome prodotto: ");
            string productName = Console.ReadLine();

            Console.WriteLine("Inserire descrizione prodotto: ");
            string productDescription = Console.ReadLine();

            Console.WriteLine("Inserire prezzo prodotto in euro: ");
            double productPrice = double.Parse(Console.ReadLine());

            Product newProduct = new Product(productName, productDescription, productPrice);

            db.Add(newProduct);
            db.SaveChanges();
        }
        break;

    case 2:
        Console.WriteLine("**** MENU ISCRIZIONE ****");
        using (EcommerceContext db = new EcommerceContext())
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo cognome: ");
            string customerSurname = Console.ReadLine();

            Console.WriteLine("Insisci la tua email: ");
            string customerEmail = Console.ReadLine();

            Customer newCustomer = new Customer(customerName, customerSurname, customerEmail);

            db.Add(newCustomer);
            db.SaveChanges();
        }
        break;

    case 3:

        using (EcommerceContext db = new EcommerceContext())
        {
            Console.WriteLine("Lista prodotti");
            List<Product> products = db.Products.OrderBy(product => product.Name).ToList<Product>();

            foreach (Product product in products)
            {
                Console.WriteLine(product.Id.ToString() + " " + product.Name);
            }
            Console.WriteLine("Selezionare cosa si vuole acquistare fino a che non digiti '9' per essere pronto all'acquisto");

            List<Product> productsCart = new List<Product>();
            List<OrderProduct> quantityProducts = new List<OrderProduct>();

            while (menuInput != 9)
            {
                menuInput = Int32.Parse(Console.ReadLine());

                foreach (Product product in products)
                {
                    if (menuInput == product.Id)
                    {
                        Console.Write("Indicare la quantità:");
                        menuInput = Int32.Parse(Console.ReadLine());
                        OrderProduct productQta = new OrderProduct(menuInput, product);
                        productsCart.Add(product);
                        quantityProducts.Add(productQta);
                        Console.WriteLine("Aggiunto");
                        break;
                    }

                }

            }

            Console.WriteLine("LogIn per chiudere ordine");

            Console.WriteLine("Inserire nome: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Inserire email: ");
            string customerEmail = Console.ReadLine();

            List<Customer> customerList = db.Customers.ToList<Customer>();

            foreach (Customer customer in customerList)
            {
                if (customer.Email == customerEmail && customer.CustomerName == customerName)
                {
                    Order newOrder = new Order(customer, productsCart);
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    foreach (OrderProduct item in quantityProducts)
                    {
                        item.OrderID = newOrder.OrderID;
                        db.OrdersProducts.Add(item);
                        db.SaveChanges();
                    }

                }

            }
        }
        break;
    case 0:
        return;
        break;
}