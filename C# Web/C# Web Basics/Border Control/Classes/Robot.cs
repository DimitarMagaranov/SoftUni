using P05_BorderControl.Interfaces;

namespace P05_BorderControl.Classes
{
	public class Robot : IRobot, IIdentifiable
	{
		public Robot(string model, string id)
		{
			this.Model = model;
			this.Id = id;
		}

		public string Model { get; private set; }

		public string Id { get; private set; }
	}
}
