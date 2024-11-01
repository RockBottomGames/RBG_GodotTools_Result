namespace RBG_GodotTools_Result.Tests;

using Chickensoft.GoDotTest;
using Godot;
using Shouldly;

public class RBG_ResultFactory_TestHelper<T> {
  public T? GetDefault(T? value = default) {
    return value;
  }
}

public partial class RBG_ResultFactory_BuildSuccessWithDefaults : TestClass {
  public RBG_ResultFactory_BuildSuccessWithDefaults(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  [Setup]
  public void Setup() => _result = RBG_ResultFactory<string>.BuildSuccess();

  [Test]
  public void Initializes() => _result.ShouldBeAssignableTo<RBG_Result<string>>();

  [Test]
  public void ValueIsDefault() => _result.Value.ShouldBe(new RBG_ResultFactory_TestHelper<string>().GetDefault());

  [Test]
  public void MessageIsEmpty() => _result.Message.ShouldBe("");

  [Test]
  public void CodeIsSuccessCode() => _result.Code.ShouldBe(RBG_Result_Constants.SUCCESS_CODE);
}

public partial class RBG_ResultFactory_BuildSuccessWithInput : TestClass {
  public RBG_ResultFactory_BuildSuccessWithInput(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_SUCCESS_VALUE = "test success value";
  private const string TEST_SUCCESS_MESSAGE = "test success message";

  [Setup]
  public void Setup() => _result = RBG_ResultFactory<string>.BuildSuccess(TEST_SUCCESS_VALUE, TEST_SUCCESS_MESSAGE);

  [Test]
  public void ValueMatchesInput() => _result.Value.ShouldBe(TEST_SUCCESS_VALUE);

  [Test]
  public void MessageMatchesInput() => _result.Message.ShouldBe(TEST_SUCCESS_MESSAGE);

  [Test]
  public void CodeIsSuccessCode() => _result.Code.ShouldBe(RBG_Result_Constants.SUCCESS_CODE);

}

public partial class RBG_ResultFactory_BuildErrorWithDefaults : TestClass {
  public RBG_ResultFactory_BuildErrorWithDefaults(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  [Setup]
  public void Setup() => _result = RBG_ResultFactory<string>.BuildError();

  [Test]
  public void Initializes() => _result.ShouldBeAssignableTo<RBG_Result<string>>();

  [Test]
  public void ValueIsDefault() => _result.Value.ShouldBe(new RBG_ResultFactory_TestHelper<string>().GetDefault());

  [Test]
  public void MessageIsEmpty() => _result.Message.ShouldBe("");

  [Test]
  public void CodeIsGenericDeveloperErrorCode() => _result.Code.ShouldBe(RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE);
}

public partial class RBG_ResultFactory_BuildErrorWithInput : TestClass {
  public RBG_ResultFactory_BuildErrorWithInput(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_ERROR_VALUE = "test error value";
  private const string TEST_ERROR_MESSAGE = "test error message";
  private const int TEST_ERROR_CODE = 42;

  [Setup]
  public void Setup() => _result = RBG_ResultFactory<string>.BuildError(TEST_ERROR_VALUE, TEST_ERROR_MESSAGE, TEST_ERROR_CODE);

  [Test]
  public void Initializes() => _result.ShouldBeAssignableTo<RBG_Result<string>>();

  [Test]
  public void ValueMatchesInput() => _result.Value.ShouldBe(TEST_ERROR_VALUE);

  [Test]
  public void MessageMatchesInput() => _result.Message.ShouldBe(TEST_ERROR_MESSAGE);


  [Test]
  public void CodeMatchesInput() => _result.Code.ShouldBe(TEST_ERROR_CODE);
}

public partial class RBG_ResultFactory_BuildErrorWithIncorrectInput : TestClass {
  public RBG_ResultFactory_BuildErrorWithIncorrectInput(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const int TEST_ERROR_CODE = -42;

  [Setup]
  public void Setup() => _result = RBG_ResultFactory<string>.BuildError("_", "_", TEST_ERROR_CODE);

  [Test]
  public void Initializes() {
    _result.ShouldBeAssignableTo<RBG_Result<string>>();
  }

  [Test]
  public void CodeIsNotIncorrectInput() {
    _result.Code.ShouldNotBe(TEST_ERROR_CODE);
  }

  [Test]
  public void CodeIsGenericDeveloperErrorCode() {
    _result.Code.ShouldBe(RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE);
  }
}
