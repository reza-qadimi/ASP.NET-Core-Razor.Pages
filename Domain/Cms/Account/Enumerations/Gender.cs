namespace Domain.Account.Enumerations
{
	public enum Gender : int
	{
		[System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Unspecified),
            ResourceType = typeof(Resources.DataDictionary))]
		Unspecified = 0,

        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Male),
            ResourceType = typeof(Resources.DataDictionary))]
		Male = 1,

        [System.ComponentModel.DataAnnotations.Display(
            Name = nameof(Resources.DataDictionary.Female),
            ResourceType = typeof(Resources.DataDictionary))]
		Female = 2,
	}
}
