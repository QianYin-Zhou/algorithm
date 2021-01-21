using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        private static TimeSpan testQueue(Queue<int> queue, int opcount)
        {
            Random rd = new Random();
            int element = rd.Next(opcount);
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();  //开始监视代码运行时间
           //需要测试的代码
           for(int i = 0; i < opcount; i++)
            {
                queue.enqueue(element);
            }
            for (int i = 0; i < opcount; i++)
            {
                queue.dequeue();
            }
            watch.Stop();  //停止监视
            TimeSpan timespan = watch.Elapsed;  //获取当前实例测量得出的总时间
            return timespan;
        }

        private static TimeSpan testHeap(int[] testData, bool isHeapify)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            MaxHeap<int> maxHeap;
            if (isHeapify)
            {
                maxHeap = new MaxHeap<int>(testData);
            }
            else
            {
                maxHeap = new MaxHeap<int>();
                for(int i = 0; i < testData.Length; i++)
                {
                    maxHeap.add(testData[i]);
                }
            }
            watch.Stop();
            //验证堆的正确性
            int[] arr = new int[testData.Length];
            for (int i = 0; i < testData.Length; i++)
            {
                arr[i] = maxHeap.extractMax();
            }
            for (int i = 1; i < testData.Length; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    throw new IndexOutOfRangeException("Error.");
                }
            }
            Console.WriteLine("您的最大堆可以了亲！");
            TimeSpan timespan = watch.Elapsed;  
            return timespan;
        }

        private  static TimeSpan testUF(UF uf, int m)
        {
            int size = uf.getSize();
            Random rd = new Random();
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start(); 
            for(int i = 0; i < m; i++)
            {
                int a = rd.Next(size);
                int b = rd.Next(size);
                uf.unionElements(a, b);
            }
            for(int i = 0; i < m; i++)
            {
                int a = rd.Next(size);
                int b = rd.Next(size);
                uf.isConnected(a, b);
            }
            watch.Stop();  
            TimeSpan timespan = watch.Elapsed;  
            return timespan;
        }

        static void Main(string[] args)
        {
            //1. 测试用例
            //int opcount = 10000;
            //Console.WriteLine("对普通队列和循环队列进行性能测试：分别出队、入队{0}次", opcount);
            //ArrayQueue<int> arrayqueue = new ArrayQueue<int>();
            //Console.WriteLine("arrayqueue times:" + testQueue(arrayqueue, opcount));
            //LoopQueue<int> loopqueue = new LoopQueue<int>();
            //Console.WriteLine("loopqueue times:" + testQueue(loopqueue, opcount));
            //LinkedListQueue<int> linkedListQueue = new LinkedListQueue<int>();
            //Console.WriteLine("linkedListQueue times:" + testQueue(linkedListQueue, opcount));
            //Console.ReadKey();
            // 2.测试栈
            //ArrayStack<string> stack1 = new ArrayStack<string>(10);
            //Console.WriteLine(stack1);
            //stack1.push("周茜茵");
            //stack1.push("不喜欢");
            //Console.WriteLine(stack1);
            //stack1.pop();
            //Console.WriteLine(stack1);
            //stack1.push("喜欢");
            //stack1.push("张炯育");
            //Console.WriteLine(stack1);
            //Console.WriteLine("请问周茜茵喜欢谁呢？{0}",stack1.peek());
            //Console.ReadKey();
            //LoopQueue<string> queue = new LoopQueue<string>(10);
            //Console.WriteLine(queue);
            //queue.enqueue("周茜茵");
            //queue.enqueue("周少柔");
            //queue.enqueue("周子荣");
            //Console.WriteLine(queue);
            //queue.dequeue();
            //Console.WriteLine(queue);
            //Console.WriteLine(queue.getFront());
            //Console.ReadKey();
            // 3.测试链表
            //LinkedList<int> ll = new LinkedList<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    ll.addLast(i);
            //}
            //ll.add(2, 99);
            //Console.WriteLine(ll.ToString());
            //Console.ReadKey();
            //ll.remove(2);
            //Console.WriteLine(ll.ToString());
            //Console.ReadKey();
            //4. 测试链栈
            //LinkedListStack<string> linkedListStack = new LinkedListStack<string>();
            //linkedListStack.push("周茜茵");
            //linkedListStack.push("郭燕璇");
            //linkedListStack.push("方法特");
            //linkedListStack.push("程少平");
            //Console.WriteLine(linkedListStack.ToString());
            //Console.ReadKey();
            // 5.测试链队列
            //LinkedListQueue<string> linkedListQueue = new LinkedListQueue<string>();
            //linkedListQueue.enqueue("郭燕璇");
            //linkedListQueue.enqueue("方法特");
            //linkedListQueue.enqueue("程少平");
            //Console.WriteLine(linkedListQueue.ToString());
            //Console.ReadKey();
            // 6.测试数组队列和链队列
            // 7. 二分搜索树
            //BST<int> bst = new BST<int>();
            //int[] nums = { 5, 3, 6, 8, 4, 2 };
            //foreach(int num in nums)
            //{
            //    bst.add(num);
            //}
            ////        5
            ////      /   \
            ////     3     6
            ////   /  \     \
            ////  2    4     8

            //Console.WriteLine("----");
            //bst.inOrder();
            //Console.WriteLine("----");
            //bst.remove(3);
            //bst.inOrder();
            // 8. 测试堆
            //int n = 1000000;
            //MaxHeap<int> heap = new MaxHeap<int>();
            //Random random = new Random();
            //int[] testData = new int[n];
            //for(int i = 0; i < n; i++)
            //{
            //    testData[i] = random.Next(int.MaxValue);
            //}
            //Console.WriteLine("is Heapify:" + testHeap(testData, true));
            //Console.WriteLine("not Heapify:" + testHeap(testData, false));
            // 9. 测试线段树
            //int[] nums = { -2, 0, 3, -5, 2, -1 };
            //Merger<int> merger = delegate(int a, int b)
            //{
            //    return a + b;
            //};
            //SegmentTree<int> segTree = new SegmentTree<int>(nums, merger);
            //Console.WriteLine(segTree.ToString());
            // 10.测试tire树
            //Trie trie = new Trie();
            //trie.add("panda");
            //Console.WriteLine(trie.contains("panda"));
            //Console.WriteLine(trie.contains("pan"));
            // 11.测试并查集的性能
            //int size = 10000000;
            //int m = 10000000;
            //UnionFind1 uf1 = new UnionFind1(size);
            //Console.WriteLine("uf1的时间：" + testUF(uf1, m) + "s");
            //UnionFind2 uf2 = new UnionFind2(size);
            //Console.WriteLine("uf2的时间：" + testUF(uf2, m) + "s");
            //UnionFind3 uf3 = new UnionFind3(size);
            //Console.WriteLine("uf3的时间：" + testUF(uf3, m) + "s");
            //UnionFind4 uf4 = new UnionFind4(size);
            //Console.WriteLine("uf4的时间：" + testUF(uf4, m) + "s");
            //UnionFind5 uf5 = new UnionFind5(size);
            //Console.WriteLine("uf5的时间：" + testUF(uf5, m) + "s");
            //UnionFind6 uf6 = new UnionFind6(size);
            //Console.WriteLine("uf6的时间：" + testUF(uf6, m) + "s");
            // 12. 对比各种数据结构的性能
            char[] ignoreChars = new char[] { ' ', ',', '?', '!', '(', ')', '\n', '\r', ':', '.' };
            string[] words = System.IO.File.ReadAllText(@"C:\Users\24050\Desktop\castle.txt")
                                            .Split(ignoreChars, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("《哈尔的移动城堡》共" + words.Length + "个单词;");
            //
            System.Diagnostics.Stopwatch listWatch = new System.Diagnostics.Stopwatch();
            listWatch.Start();
            LinkedListMap<string, int> linkedListMap = new LinkedListMap<string, int>();
            foreach (string word in words)
            {
                if (linkedListMap.contains(word))
                {
                    linkedListMap.set(word, linkedListMap.get(word) + 1);
                }
                else
                {
                    linkedListMap.add(word, 1);
                }
            }
            foreach (string word in words)
            {
                linkedListMap.contains(word);
            }
            listWatch.Stop();
            TimeSpan listTimespan = listWatch.Elapsed;
            Console.WriteLine(listTimespan + "s:垃圾链表");
            // 
            System.Diagnostics.Stopwatch bstWatch = new System.Diagnostics.Stopwatch();
            bstWatch.Start();
            BSTMap<string, int> bSTMap = new BSTMap<string, int>();
            foreach (string word in words)
            {
                if (bSTMap.contains(word))
                {
                    bSTMap.set(word, bSTMap.get(word) + 1);
                }
                else
                {
                    bSTMap.add(word, 1);
                }
            }
            foreach (string word in words)
            {
                bSTMap.contains(word);
            }
            bstWatch.Stop();
            TimeSpan bstTimespan = bstWatch.Elapsed;
            Console.WriteLine(bstTimespan + "s:普通BST");
            //
            System.Diagnostics.Stopwatch avlWatch = new System.Diagnostics.Stopwatch();
            avlWatch.Start();
            AVLTree<string, int> aVLTree = new AVLTree<string, int>();
            foreach (string word in words)
            {
                if (aVLTree.contains(word))
                {
                    aVLTree.set(word, aVLTree.get(word) + 1);
                }
                else
                {
                    aVLTree.add(word, 1);
                }
            }
            foreach (string word in words)
            {
                aVLTree.contains(word);
            }
            avlWatch.Stop();
            TimeSpan avlTimespan = avlWatch.Elapsed;
            Console.WriteLine(avlTimespan + "s:高级AVL");
            //
            System.Diagnostics.Stopwatch rbTreeWatch = new System.Diagnostics.Stopwatch();
            rbTreeWatch.Start();
            RBTree<string, int> rbTree = new RBTree<string, int>();
            foreach (string word in words)
            {
                if (rbTree.contains(word))
                {
                    rbTree.set(word, rbTree.get(word) + 1);
                }
                else
                {
                    rbTree.add(word, 1);
                }
            }
            foreach (string word in words)
            {
                rbTree.contains(word);
            }
            rbTreeWatch.Stop();
            TimeSpan rbTreeTimespan = rbTreeWatch.Elapsed;
            Console.WriteLine(rbTreeTimespan + "s:花里胡哨红黑树");
            //
            System.Diagnostics.Stopwatch hashTableWatch = new System.Diagnostics.Stopwatch();
            hashTableWatch.Start();
            HashTable<string, int> hashTable = new HashTable<string, int>();
            foreach (string word in words)
            {
                if (hashTable.contains(word))
                {
                    hashTable.set(word, hashTable.get(word) + 1);
                }
                else
                {
                    hashTable.add(word, 1);
                }
            }
            foreach (string word in words)
            {
                hashTable.contains(word);
            }
            hashTableWatch.Stop();
            TimeSpan hashTableTimespan = hashTableWatch.Elapsed;
            Console.WriteLine(hashTableTimespan + "s:哈希表");
            Console.WriteLine("实际单词有" + bSTMap.getSize() + "个");
        }
    }
}
