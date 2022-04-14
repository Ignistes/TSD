def factorial (x)
  puts (1..x).reduce(:*)
end

factorial(5)

module InstanceModule
  def square
    puts self * self
  end
end

module ClassModule
  def sample(size)
    a = Array.new(size) { |i| rand(0..9)}
    a.map { |i| puts i}
  end
end

class Integer
  include InstanceModule
  extend ClassModule
  def factorial
    if self < 0 then raise "Runtime error: cannot count factorial for negative number" end
     puts (1..self).reduce(:*)
  end
end

5.factorial
# -5.factorial
5.square
Integer.sample(5)