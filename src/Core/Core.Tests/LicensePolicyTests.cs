﻿using Xunit;

namespace LicenseInspector.Core.Tests
{
    public class LicensePolicyTests
    {
        [Fact]
        public void ApplyLicensePolicy_DifferentLicenseCasing_EvaluationOk()
        {
            var policy = new LicensePolicy
            {
                License = "MS-PL",
                Allow = true
            };
            var packagePolicies = new PackagePolicies(new PackagePolicy[] { });
            var policies = new LicensePolicies(new[] { policy }, packagePolicies);

            var package = new LicensedPackage("test-id", "1.0.0", "Ms-PL", string.Empty);
       
            var result = policies.Apply(package);

            Assert.Equal(Evaluation.Ok, result.Result);
        }

    }
}
