namespace API.DTOs
{
	public class LoginDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public BasketDto Basket { get; set; }
	}
}