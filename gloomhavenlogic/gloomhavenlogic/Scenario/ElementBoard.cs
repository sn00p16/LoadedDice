using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Scenario
{
    public sealed class ElementBoard
    {
        public ElementBoard()
        {
            Elements = new Dictionary<Element, ElementBoardEntry>();
            for (Element element = 0; element < Element.Max; ++element)
                Elements.Add(element, new ElementBoardEntry());
        }

        public Dictionary<Element, ElementBoardEntry> Elements { get; private set; }

        public void InitializeBoard()
        {
            UseElement(Element.All);
        }

        public void EndRound()
        {
            foreach (var element in Elements)
                element.Value.WeakenElement();
        }

        public void GenerateElement(Element element)
        {
            if (element == Element.All)
                foreach (var el in Elements)
                    el.Value.GenerateElement();

            else
                Elements[element].GenerateElement();
        }

        public void UseElement(Element element)
        {
            if (element == Element.All)
            {
                foreach (var el in Elements)
                    el.Value.UseElement();
            }

            else if (element == Element.Any)
            {
                foreach (var el in Elements)
                {
                    if (el.Value.IsUseable)
                    {
                        el.Value.UseElement();
                        return;
                    }
                }
            }

            else
                Elements[element].UseElement();
        }

        #region Element Checks

        public bool IsElementInert(Element element)
        {
            if (element == Element.Any)
                return GetInertElementCount() > 0;

            return Elements[element].IsInert;
        }

        public bool IsElementWaning(Element element)
        {
            if (element == Element.Any)
                return GetWaningElementCount() > 0;

            return Elements[element].IsWaning;
        }

        public bool IsElementStrong(Element element)
        {
            if (element == Element.Any)
                return GetStrongElementCount() > 0;

            return Elements[element].IsStrong;
        }

        public bool IsElementUseable(Element element)
        {
            if (element == Element.Any)
                return GetUseableElementCount() > 0;

            return Elements[element].IsUseable;
        }

        #endregion

        #region Element Counts

        public int GetInertElementCount()
        {
            int count = 0;
            foreach (var element in Elements)
                count += element.Value.IsInert ? 1 : 0;

            return count;
        }

        public int GetWaningElementCount()
        {
            int count = 0;
            foreach (var element in Elements)
                count += element.Value.IsWaning ? 1 : 0;

            return count;
        }

        public int GetStrongElementCount()
        {
            int count = 0;
            foreach (var element in Elements)
                count += element.Value.IsStrong ? 1 : 0;

            return count;
        }

        public int GetUseableElementCount()
        {
            int count = 0;
            foreach (var element in Elements)
                count += element.Value.IsUseable ? 1 : 0;

            return count;
        }

        #endregion

        #region Singleton Implementation

        private static ElementBoard instance = null;
        private static readonly object padlock = new object();

        public static ElementBoard Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ElementBoard();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
