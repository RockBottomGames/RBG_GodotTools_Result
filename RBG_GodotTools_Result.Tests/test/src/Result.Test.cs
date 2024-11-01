namespace RBG_GodotTools_Result.Tests;

using Chickensoft.GoDotTest;
using Godot;
using RBG_GodotTools_AutoTest;
using Shouldly;

public partial class RBG_Result_Constants_Tests : TestClass {
  public RBG_Result_Constants_Tests(Node testScene) : base(testScene) {
  }

  [Test]
  public void NotEvaluatedCodeIsNegativeOne() => RBG_Result_Constants.NOT_EVALUATED_CODE.ShouldBe(-1);

  [Test]
  public void SuccessCodeIsZero() => RBG_Result_Constants.SUCCESS_CODE.ShouldBe(0);

  [Test]
  public void GenericDeveloperErrorCodeIsOne() => RBG_Result_Constants.GENERIC_DEVELOPER_ERROR_CODE.ShouldBe(1);
}

public partial class RBG_Result_WithDefaults : TestClass {
  public RBG_Result_WithDefaults(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  [Setup]
  public void Setup() => _result = new RBG_Result<string>();

  [Test]
  public void Initializes() => _result.ShouldBeAssignableTo<RBG_Result<string>>();

  [Test]
  public void MessageIsEmpty() => _result.Message.ShouldBe("");

  [Test]
  public void CodeIsNotEvaluatedCode() => _result.Code.ShouldBe(RBG_Result_Constants.NOT_EVALUATED_CODE);
}

public partial class RBG_Result_WithFullInput : TestClass {
  public RBG_Result_WithFullInput(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_VALUE = "test inputs value";
  private const string TEST_MESSAGE = "test inputs message";
  private const int TEST_CODE = -42;

  [Setup]
  public void Setup() => _result = new RBG_Result<string>(TEST_VALUE, TEST_MESSAGE, TEST_CODE);

  [Test]
  public void Initializes() => _result.ShouldBeAssignableTo<RBG_Result<string>>();

  [Test]
  public void MessageMatchesInput() => _result.Message.ShouldBe(TEST_MESSAGE);

  [Test]
  public void CodeMatchesInput() => _result.Code.ShouldBe(TEST_CODE);
}

public partial class RBG_Result_WithInputForNotEvaluated : TestClass {
  public RBG_Result_WithInputForNotEvaluated(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_VALUE = "test not evaluated value";
  private const string TEST_MESSAGE = "test not evaluated message";
  private const int TEST_CODE = RBG_Result_Constants.NOT_EVALUATED_CODE;

  [Setup]
  public void Setup() => _result = new RBG_Result<string>(TEST_VALUE, TEST_MESSAGE, TEST_CODE);

  [Test]
  public void IsEvaluatedIsTrue() => _result.IsEvaluated.ShouldBeFalse();

  [Test]
  public void IsErrorIsTrue() => _result.IsError.ShouldBeFalse();
}

public partial class RBG_Result_WithInputForSuccess : TestClass {
  public RBG_Result_WithInputForSuccess(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_VALUE = "test success value";
  private const string TEST_MESSAGE = "test success message";
  private const int TEST_CODE = RBG_Result_Constants.SUCCESS_CODE;

  [Setup]
  public void Setup() => _result = new RBG_Result<string>(TEST_VALUE, TEST_MESSAGE, TEST_CODE);

  [Test]
  public void IsEvaluatedIsTrue() => _result.IsEvaluated.ShouldBeTrue();

  [Test]
  public void IsErrorIsTrue() => _result.IsError.ShouldBeFalse();
}

public partial class RBG_Result_WithInputForError : TestClass {
  public RBG_Result_WithInputForError(Node testScene) : base(testScene) {
    _result = new RBG_Result<string>();
  }

  private RBG_Result<string> _result;

  private const string TEST_VALUE = "test error value";
  private const string TEST_MESSAGE = "test error message";
  private const int TEST_CODE = 42;

  [Setup]
  public void Setup() => _result = new RBG_Result<string>(TEST_VALUE, TEST_MESSAGE, TEST_CODE);

  [Test]
  public void IsEvaluatedIsTrue() => _result.IsEvaluated.ShouldBeTrue();

  [Test]
  public void IsErrorIsTrue() => _result.IsError.ShouldBeTrue();
}

public class RBG_Result_BaseEquality : BaseEquality<RBG_Result<string>, string> {
  public RBG_Result_BaseEquality(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeDefaultValue() => new();

  public override RBG_Result<string> MakeFilledValue() => new("Test filled value.", "Test filled message.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;

  public override string MakeOtherType() => "Test string.";
}

public class RBG_Result_EqualityValueDiff : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityValueDiff(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeObj1() => new("Test value difference value.", "Test value difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new("This is different.", "Test value difference message.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}

public class RBG_Result_EqualityValueDiffObj1NullValue : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityValueDiffObj1NullValue(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeObj1() => new(null, "Test value difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new("Test value difference value.", "Test value difference message.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}

public class RBG_Result_EqualityValueDiffObj2NullValue : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityValueDiffObj2NullValue(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeObj1() => new("Test value difference value.", "Test value difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new(null, "Test value difference message.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}

public class RBG_Result_EqualityValueDiffBothNullValue : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityValueDiffBothNullValue(Node testScene) : base(testScene) {
    IsEqual = true;
  }

  public override RBG_Result<string> MakeObj1() => new(null, "Test value difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new(null, "Test value difference message.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}

public class RBG_Result_EqualityMessageDiff : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityMessageDiff(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeObj1() => new("Test message difference value.", "Test message difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new("Test message difference value.", "This is different.", 42);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}

public class RBG_Result_EqualityCodeDiff : EdgeCaseComparisonEquality<RBG_Result<string>> {
  public RBG_Result_EqualityCodeDiff(Node testScene) : base(testScene) {
  }

  public override RBG_Result<string> MakeObj1() => new("Test code difference value.", "Test code difference message.", 42);

  public override RBG_Result<string> MakeObj2() => new("Test code difference value.", "Test code difference message.", 9001);

  public override bool RunEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho == rho;

  public override bool RunNotEqualsOperator(RBG_Result<string>? lho, RBG_Result<string>? rho) => lho != rho;
}
