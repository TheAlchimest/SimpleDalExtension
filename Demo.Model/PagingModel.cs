using System;

namespace Demo.Model
{
    public class ElsPaging
    {
        //default values
        int _PageSize = 10;
        int _PaggingCount = 5;
        int _TotalPages;
        int _CurrentPage = 1;
        int _TotalRecords;
        int _StartPage = 1;
        int _EndPage;
        int _PreviousPages;
        int _PreviousPageIndex;
        int _NextPageIndex;
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }
        public int TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }
        }
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }
        public int StartPage
        {
            get { return _StartPage; }
            set { _StartPage = value; }
        }
        public int EndPage
        {
            get { return _EndPage; }
            set { _EndPage = value; }
        }
        public int TotalPages
        {
            get { return _TotalPages; }
            set { _TotalPages = value; }
        }
        public int PreviousPageIndex
        {
            get { return _PreviousPageIndex; }
            set { _PreviousPageIndex = value; }
        }
        public int NextPageIndex
        {
            get { return _NextPageIndex; }
            set { _NextPageIndex = value; }
        }
        public string UrlPattern { get; set; } = "/{0}/";

        public bool IsValid { get; set; } = true;
        public int ItemNoFrom { get; set; }
        public int ItemNoTo { get; set; }
        private ElsPaging() { }
        public ElsPaging(int pageIndex, int totalRecords, int pageSize, int paggingCount, string sigularText, string pluralText)
        {
            _CurrentPage = pageIndex;
            _PageSize = pageSize;
            _TotalRecords = totalRecords;
            _PaggingCount = paggingCount;
            PreparePagging();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_TotalRecords"></param>
        public void PreparePagging()
        {
            if (_TotalRecords == 0)
            {
                this.IsValid = false;
                return;
            }
            //
            if (_PageSize > _TotalRecords)
                _PageSize = _TotalRecords;
            //_TotalPages
            _TotalPages = (_TotalRecords / PageSize);
            if (_TotalRecords % PageSize > 0)
                _TotalPages += 1;
            if (_TotalPages == 1)
            {
                this.IsValid = false;
            }

            //_TotalPages
            _TotalPages = _TotalRecords / PageSize;
            if (_TotalRecords % PageSize > 0)
                _TotalPages += 1;
            //_PaggingCount
            if (_PaggingCount > _TotalPages)
                _PaggingCount = _TotalPages;
            //_PreviousPages
            _PreviousPages = _PaggingCount / 2;
            if (_PaggingCount % 2 > 0)
                _PreviousPages += 1;

            //--------------------------------------------------
            //Calculate first page and end Page in current pagination view
            //_StartPage
            if (_CurrentPage > _PreviousPages + 1)
                _StartPage = _CurrentPage - _PreviousPages;
            if (_StartPage < 1)
                _StartPage = 1;
            //-------------------------
            //_EndPage
            _EndPage = _StartPage + _PaggingCount - 1;
            if (_EndPage > _TotalPages)
                _EndPage = _TotalPages;
            if (_EndPage - _StartPage < _PaggingCount)
                _StartPage = _EndPage - _PaggingCount + 1;
            //--------------------------------------------------
            //calculate items from to
            ItemNoFrom = ((_CurrentPage - 1) * _PageSize) + 1;
            ItemNoTo = ItemNoFrom + _PageSize - 1;
            if (ItemNoFrom > _TotalRecords)
                ItemNoTo = _TotalRecords;

            #region Next---Last
            //Next ---------------------------------------------
            if (_CurrentPage < _TotalPages)
            {
                _NextPageIndex = _CurrentPage + 1;
            }
            else
            {
                _NextPageIndex = 0;

            }

            //--------------------------------------------------
            #endregion


            string previosColumns = "";
            if (PageSize > _TotalRecords)
                previosColumns = Convert.ToString(_TotalRecords);
            else
                previosColumns = Convert.ToString((_CurrentPage * PageSize));
        }
    }
}