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
Console.WriteLine("0- Esci");


int menuInput = Int32.Parse(Console.ReadLine());

switch (menuInput)
{
    case 1:
        Console.WriteLine("**** MENU AGGIUNGI PRODOTTO ****");

        break;
    case 0:
        return;
        break;
}