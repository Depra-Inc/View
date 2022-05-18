using System.Collections;
using Depra.View.Runtime;
using Depra.View.Runtime.Switches.Facades;
using Depra.View.Runtime.Switches.Implementations.CanvasGroup;
using Depra.View.Runtime.Switches.Implementations.Transform;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Depra.View.Tests.Playmode
{
    public class ViewVisibilitySwitchTests : MonoBehaviour
    {
        private ViewVisibilitySwitchHook _viewVisibilitySwitchHook;

        private static float AnimationDuration => Constants.DefaultAnimationDuration;
        
        [SetUp]
        public void Setup()
        {
            _viewVisibilitySwitchHook = CreateObjectForTest();
        }

        [TearDown]
        public void Teardown()
        {
            Destroy(_viewVisibilitySwitchHook.gameObject);
        }
        
        [UnityTest]
        public IEnumerator Transform_Root_Can_Be_Disabled_And_Enabled()
        {
            _viewVisibilitySwitchHook.ChangeType(new TransformRootVisibilitySwitch());
            _viewVisibilitySwitchHook.Reset();
            
            _viewVisibilitySwitchHook.Hide();
            
            yield return null;
            Assert.IsFalse(_viewVisibilitySwitchHook.Visible);
        
            _viewVisibilitySwitchHook.Show();
            
            yield return null;
            Assert.IsTrue(_viewVisibilitySwitchHook.Visible);
        }

        [UnityTest]
        public IEnumerator CanvasGroup_Root_Can_Be_Disabled_And_Enabled()
        {
            _viewVisibilitySwitchHook.gameObject.AddComponent<CanvasGroup>();
            _viewVisibilitySwitchHook.ChangeType(new CanvasGroupRootVisibilitySwitch());
            _viewVisibilitySwitchHook.Reset();
            
            _viewVisibilitySwitchHook.Hide();
            
            yield return new WaitForSeconds(AnimationDuration);
            Assert.IsFalse(_viewVisibilitySwitchHook.Visible);
        
            _viewVisibilitySwitchHook.Show();
            
            yield return new WaitForSeconds(AnimationDuration);
            Assert.IsTrue(_viewVisibilitySwitchHook.Visible);
        }

        private static ViewVisibilitySwitchHook CreateObjectForTest()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var rootBehavior = obj.AddComponent<ViewVisibilitySwitchHook>();

            return rootBehavior;
        }
    }
}
