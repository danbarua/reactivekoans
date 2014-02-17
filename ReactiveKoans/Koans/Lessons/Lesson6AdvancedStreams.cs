using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using Koans.Utils;
using Xunit;

namespace Koans.Lessons
{
	
	public class Lesson6AdvancedStreams
	{
		[Fact]
		public void Merging()
		{
			var easy = new StringBuilder();
			var you = new object[] {1, 2, 3}.ToObservable();
			var me = new object[] {"A", "B", "C"}.ToObservable();
			you.Merge(me).Subscribe(a => easy.Append(a + " "));
			Assert.Equal(easy.ToString(), ___);
		}

		[Fact]
		public void MergingEvents()
		{
			var first = new List<String>();
			var both = new List<String>();
			var s1 = new Subject<String>();
			var s2 = new Subject<String>();
			s1.Subscribe(s => first.Add(s));
			s1.Merge(s2).Subscribe(s => both.Add(s));


			s1.OnNext("I");
			s1.OnNext("am");
			s2.OnNext("nobody.");
			s2.OnNext("Nobody");
			s2.OnNext("is");
			s1.OnNext("perfect.");
			
			Assert.Equal("I am nobody. Nobody is perfect.", String.Join(" ",both));
			Assert.Equal(___, String.Join(" ",first));
		}


		[Fact]
		public void SplittingUp()
		{
			var oddsAndEvens = new[] {"", ""};
			var numbers = Observable.Range(1, 9);
			var split = numbers.GroupBy(n => n% ____);
			split.Subscribe((IGroupedObservable<int, int> group) => group.Subscribe(n => oddsAndEvens[group.Key] += n));
			var evens = oddsAndEvens[0];
			var odds = oddsAndEvens[1];
			Assert.Equal("2468", evens);
			Assert.Equal("13579", odds);
		}

		[Fact]
		public void NeedToSubscribeImediatelyWhenSplitting()
		{
			var averages = new[] {0.0, 0.0};
			var numbers = new[] {22, 22, 99, 22, 101, 22}.ToObservable();
			var split = numbers.GroupBy(n => n%2);
			split.Subscribe((IGroupedObservable<int, int> g) => g.Average().____(a => averages[g.Key] = a));
			Assert.Equal(22, averages[0]);
			Assert.Equal(100, averages[1]);
		}

		[Fact]
		public void MultipleSubscriptions()
		{
			var numbers = new Subject<int>();
			double sum = 0;
			double average = 0;
			numbers.Sum().Subscribe(n => sum = n);
			numbers.OnNext(1, 1, 1, 1, 1);
			numbers.Average().Subscribe(n => average = n);
			numbers.OnNext(2, 2, 2, 2, 2);
			numbers.OnCompleted();
			Assert.Equal(15, sum);
			Assert.Equal(average, ___);
		}

		#region Ignore

		public object ___ = "Please Fill in the blank";
		public int ____ = 1;

		#endregion

		/*
				 * async,
				 * behavor
				 * replay
				 */
	}
}