using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMergeKSortedListsCSharp
{

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            ListNode head = UnqueueNodeWithMinValue(lists);
            if (head == null)
                return null;

            ListNode tail = head;

            ListNode nextNode;
            while ((nextNode = UnqueueNodeWithMinValue(lists)) != null)
            {
                tail.next = nextNode;
                tail = tail.next;
            }

            return head;
        }

        private ListNode UnqueueNodeWithMinValue(ListNode[] lists)
        {
            int minVal = int.MaxValue;
            ListNode nodeWithMinValue = null;
            ListNode replacementHeadForNodeWithMinValue = null;
            int indexOfListWithMinVal = 0;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null && lists[i].val < minVal)
                {
                    nodeWithMinValue = lists[i];
                    replacementHeadForNodeWithMinValue = nodeWithMinValue.next;
                    indexOfListWithMinVal = i;
                    minVal = lists[i].val;
                }
            }

            // Replace head of list[indexOfListWithMinVal
            lists[indexOfListWithMinVal] = replacementHeadForNodeWithMinValue;

            return nodeWithMinValue;
        }
    }
}