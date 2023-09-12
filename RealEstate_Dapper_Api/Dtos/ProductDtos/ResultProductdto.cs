namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
	public class ResultProductdto
	{
		public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int CategoryId { get; set; }
    }
}