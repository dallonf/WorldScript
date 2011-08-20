using System;

	
	public delegate void ParamEventHandler<T>(object sender, ParamEventArgs<T> e);

	public class ParamEventArgs<T> : EventArgs
	{
		public T Value {get; set;}
			
		public ParamEventArgs (T value)
		{
			Value = value;
		}
	}

