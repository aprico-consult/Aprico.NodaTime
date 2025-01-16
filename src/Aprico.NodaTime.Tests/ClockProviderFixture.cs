#region region Copyright & License

// Copyright © 2024 - 2025 Aprico Consultants
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Aprico.AutoFixture.Xunit2;
using AutoFixture.Xunit2;
using MicroElements.AutoFixture.NodaTime;
using NodaTime;

namespace Aprico;

public class ClockProviderFixture
{
	[Theory]
	[AutoData]
	public void CanSetupGetCurrentInstant(Instant instant)
	{
		using var clockProvider = new ClockProviderMockInjectionScope();
		clockProvider.Mock.Setup(static m => m.GetCurrentInstant())
			.Returns(instant);

		ClockProvider.Instance.GetCurrentInstant()
			.Should()
			.Be(instant);
	}

	[Theory]
	[AutoData]
	public void CanSetupNow(Instant now)
	{
		using var clockProvider = new ClockProviderMockInjectionScope();
		clockProvider.Mock.Setup(static m => m.Now)
			.Returns(now);

		ClockProvider.Instance.Now.Should()
			.Be(now);
	}

	[Theory]
	[AutoData<NodaTimeCustomization>]
	public void CanSetupToday(LocalDate today)
	{
		using var clockProvider = new ClockProviderMockInjectionScope();
		clockProvider.Mock.Setup(static m => m.Today)
			.Returns(today);

		ClockProvider.Instance.Today.Should()
			.Be(today);
	}

	[Theory]
	[AutoData]
	public void CanSetupUtcNow(ZonedDateTime now)
	{
		using var clockProvider = new ClockProviderMockInjectionScope();
		clockProvider.Mock.Setup(static m => m.UtcNow)
			.Returns(now);

		ClockProvider.Instance.UtcNow.Should()
			.Be(now);
	}
}
