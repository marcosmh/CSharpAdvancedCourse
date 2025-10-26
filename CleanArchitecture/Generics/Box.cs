﻿using System;

namespace Generics
{
	public class Box<T>
	{
		private T _value;

		public Box(T value)
			=> _value = value;

		public string GetContent()
			=> _value.ToString();

		public T Get()
			=> _value;

		public void Set(T value)
			=> _value = value;


	}
}

