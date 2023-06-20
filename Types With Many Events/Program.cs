using System;
//using System.Windows.Forms;

// ref link:https://www.youtube.com/watch?v=CNGDMuATPHM&list=PLAE7FECFFFCBE1A54&index=20
// Static string Event vs Many events

class Cow
{   // Delegate references = 4 bytes
    //private EventHandler beginMoo; // 4 bytes
    private Dictionary<string, EventHandler> subscribers =
        new Dictionary<string, EventHandler>();
    
        // static string 18 bytes of memory
    const string BeginMooKey = "Begin moo"; // 9 char added = 18 bytes // const variable -- the compiler make it static
    public event EventHandler BeginMoo //  save 4 bytes of memory
    {
        add
        {
            //beginMoo += value;
            /*if (subscribers.ContainsKey(BeginMooKey))
                subscribers[BeginMooKey] += value;
            else
                subscribers.Add(BeginMooKey, value); //1st sub */
            addSubscriber(BeginMooKey, value);
        }
        remove
        {
            //beginMoo -= value;
            if (!subscribers.ContainsKey(BeginMooKey))
                return;
            subscribers[BeginMooKey] -= value;
            if (subscribers[BeginMooKey] == null)
                subscribers.Remove(BeginMooKey);
        }
    }
    void addSubscriber(string key, EventHandler subscriber)
    {
        if (subscribers.ContainsKey(BeginMooKey))
            subscribers[BeginMooKey] += subscriber;
        else
            subscribers.Add(BeginMooKey, subscriber); //1st sub
    }

        //  multiple events = +4+4+4bytes+..... 
    public event EventHandler Moo;  // 4 bytes
    public event EventHandler EndMoo;   // 4 bytes
    public event EventHandler BeginWalking; // 4 bytes
    public event EventHandler Walk; // 4 bytes
    public event EventHandler EndWalking;   // 4 bytes
    public event EventHandler BeginSleeping;    // 4 bytes
    public event EventHandler Sleeping; // 4 bytes
    public event EventHandler EndSleeping;  // 4 bytes
}

class MainClass
{
    static void Main()
    {

    }
}