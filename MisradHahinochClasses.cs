class Node<T>
{
    private T value;
    private Node<T> next;

    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }
    public T GetValue()
    {
        return this.value;
    }
    public Node<T> GetNext()
    {
        return this.next;
    }
    public bool HasNext()
    {
        return this.GetNext() != null;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }

    public void SetNext(Node<T> next)
    {
        this.next = next;
    }

    public override string ToString()
    {
        Node<T> pos=this;
        string str="[";
        while (pos.HasNext())
        {
            str += pos.value + ",";
            pos = pos.next;
        }
        str += pos.value + "]";
        return str;
    }
}

class Stack<T>
{
    private Node<T> first;

    public Stack()
    {
        this.first = null;
    }

    public bool IsEmpty()
    {
        return this.first == null;
    }

    public void Push(T x)
    {
        this.first = new Node<T>(x, this.first);
    }

    public T Top()
    {
        return this.first.GetValue();
    }

    public T Pop()
    {
        T x = this.first.GetValue();
        this.first = this.first.GetNext();
        return x;
    }

    public override string ToString()
    {
        string str = "[";
        Node<T> pos = this.first;
        while (pos != null)
        {
            str = str + pos.GetValue().ToString();
            if (pos.HasNext())
                str = str + ",";
            pos = pos.GetNext();
        }
        str = str + "]";
        return str;
    }
}

class Queue<T>
{
    private Node<T> first;
    private Node<T> last;


    public Queue()
    {
        this.first = null;
        this.last = null;
    }
    public void Insert(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (this.first == null)
                this.first = newNode;
            else
            this.last.SetNext(newNode);
        this.last = newNode;
    }
    public T Remove()
    {
        T value = this.first.GetValue();
        this.first = this.first.GetNext();
        if (this.first == null)
            this.last = null;
        return value;
    }
    public T Head()
    {
        return this.first.GetValue();
    }

    public bool IsEmpty()
    {
        return this.first == null;
    }

    public override string ToString()
    {
        return "" + this.first;
    }
}