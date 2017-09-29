using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace KataAOP.Test
{
    public class PropertyChangerFixture
    {
        private PropertyChanger _testee;
        private List<string> _list;

        public PropertyChangerFixture()
        {
            _testee = new PropertyChanger();
            _list = new List<string>();
            _testee.PropertyChanged += (sender, args) => { _list.Add(args.PropertyName); };
        }

        [Fact]
        public void GivenName_WhenChanged_RaisesEvent()
        {
            // Act
            _testee.GivenName = "Kevin";
            
            // Assert
            _list.Count.Should().Be(2);
            _list.ShouldBeEquivalentTo(new [] {nameof(_testee.GivenName), nameof(_testee.FullName)});
        }
    }
}